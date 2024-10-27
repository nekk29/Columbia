using AutoMapper;
using IdentityServer4.Events;
using IdentityServer4.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using $safesolutionname$.Common;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Domain.Extensions;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.User
{
    public class LoginCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IMediator mediator,
        LoginCommandValidator validator,
        IEventService eventService,
        IConfiguration configuration,
        IIdentityServerInteractionService interaction,
        UserManager<Entity.ApplicationUser> userManager,
        SignInManager<Entity.ApplicationUser> signInManager
    ) : CommandHandlerBase<LoginCommand, LoginResultDto>(unitOfWork, mapper, mediator, validator)
    {
        public override async Task<ResponseDto<LoginResultDto>> HandleCommand(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<LoginResultDto>();
            var loginResultDto = new LoginResultDto();

            var username = request.LoginDto.UserName;
            var returnUrl = request.LoginDto.ReturnUrlOrDefault();
            var returnUrlEncoded = UriUtils.EncodeUri(returnUrl);
            var lockoutOnFailure = configuration.GetValue<bool>("SignInOptions:LockoutEnabled");

            var applicationUser = await userManager.FindByNameAsync(username!);
            applicationUser ??= await userManager.FindByEmailAsync(username!);

            var context = await interaction.GetAuthorizationContextAsync(returnUrl);
            var result = await signInManager.PasswordSignInAsync(applicationUser?.UserName!, request.LoginDto.Password!, request.LoginDto.RememberMe, lockoutOnFailure: lockoutOnFailure);

            if (result.Succeeded)
            {
                if (context != null)
                {
                    var issuer = configuration.GetValue<string>("SecurityOptions:Issuer");
                    loginResultDto.ReturnUrl = $"{issuer}{returnUrl}";
                    await eventService.RaiseAsync(new UserLoginSuccessEvent(username, username, applicationUser!.Email, true, clientId: context?.Client.ClientId));
                }
                else
                    loginResultDto.ReturnUrl = returnUrl;

                response.UpdateData(loginResultDto);
                response.AddOkResult(Resources.User.LoginSucceeded);

                return response;
            }

            var isEmailConfirmed = await userManager.IsEmailConfirmedAsync(applicationUser!);

            if (userManager.Options.SignIn.RequireConfirmedAccount && !isEmailConfirmed)
            {
                response.AddErrorResult(Resources.User.LoginEmailNotConfirmed);
                return response;
            }

            if (result.RequiresTwoFactor)
            {
                var frontUrl = configuration.GetValue<string>("SecurityOptions:FrontUrl");
                loginResultDto.ReturnUrl = $"{frontUrl}/#/user/login-with-2fa?returnUrl={returnUrlEncoded}";
                response.AddErrorResult(Resources.User.Login2FARequired);
                return response;
            }

            if (result.IsLockedOut)
            {
                var lockoutAttempts = configuration.GetValue<int>("SignInOptions:LockoutMaxFailedAccessAttempts");
                var lockoutTimeInMinutes = configuration.GetValue<int>("SignInOptions:LockoutDefaultTimeSpanInMinutes");

                response.AddErrorResult(string.Format(Resources.User.LoginLockout, lockoutAttempts, lockoutTimeInMinutes));

                return response;
            }

            response.AddErrorResult(Resources.User.LoginFailed);

            return response;
        }
    }
}
