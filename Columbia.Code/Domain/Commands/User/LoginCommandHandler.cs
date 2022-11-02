using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Domain.Commands.Token;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using $safesolutionname$.Repository.Abstractions.Transactions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace $safesolutionname$.Domain.Commands.User
{
    public class LoginCommandHandler : CommandHandlerBase<LoginCommand, LoginResultDto>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Entity.ApplicationUser> _userManager;
        private readonly SignInManager<Entity.ApplicationUser> _signInManager;

        public LoginCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            LoginCommandValidator validator,
            IConfiguration configuration,
            UserManager<Entity.ApplicationUser> userManager,
            SignInManager<Entity.ApplicationUser> signInManager
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public override async Task<ResponseDto<LoginResultDto>> HandleCommand(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<LoginResultDto>();
            var lockoutOnFailure = _configuration.GetValue<bool>("SignInOptions:LockoutEnabled");
            var result = await _signInManager.PasswordSignInAsync(request.LoginDto.UserName, request.LoginDto.Password, request.LoginDto.RememberMe, lockoutOnFailure: lockoutOnFailure);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(request.LoginDto.UserName);
                var accessToken = await _mediator?.Send(new GenerateTokenCommand(user), cancellationToken)!;

                if (accessToken?.Data == null)
                {
                    response.AddErrorResult(Resources.User.LoginAccessTokenError);
                    return response;
                }

                response.UpdateData(new LoginResultDto { AccessToken = accessToken?.Data });
                response.AddOkResult(Resources.User.LoginSucceeded);

                return response;
            }

            var applicationUser = await _userManager.FindByNameAsync(request.LoginDto.UserName);

            if (applicationUser == null)
                applicationUser = await _userManager.FindByEmailAsync(request.LoginDto.UserName);

            var isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(applicationUser);

            if (_userManager.Options.SignIn.RequireConfirmedAccount && !isEmailConfirmed)
            {
                response.AddErrorResult(Resources.User.LoginEmailNotConfirmed);
                return response;
            }

            if (result.RequiresTwoFactor)
            {
                response.AddErrorResult(Resources.User.Login2FARequired);
                return response;
            }

            if (result.IsLockedOut)
            {
                var lockoutAttempts = _configuration.GetValue<int>("SignInOptions:LockoutMaxFailedAccessAttempts");
                var lockoutTimeInMinutes = _configuration.GetValue<int>("SignInOptions:LockoutDefaultTimeSpanInMinutes");

                response.AddErrorResult(string.Format(Resources.User.LoginLockout, lockoutAttempts, lockoutTimeInMinutes));

                return response;
            }

            response.AddErrorResult(Resources.User.LoginFailed);

            return response;
        }
    }
}
