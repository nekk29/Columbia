using System.Net;
using System.Text;
using AutoMapper;
using Company.Product.Module.Common;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Domain.Commands.Email;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Email;
using Company.Product.Module.Dto.User;
using Company.Product.Module.Entity;
using Company.Product.Module.Repository.Abstractions.Transactions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Company.Product.Module.Domain.Commands.User
{
    public class ForgotPasswordCommandHandler : CommandHandlerBase<ForgotPasswordCommand>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ForgotPasswordCommandHandler> _logger;

        public ForgotPasswordCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            ForgotPasswordCommandValidator validator,
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            ILogger<ForgotPasswordCommandHandler> logger
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
        }

        public override async Task<ResponseDto> HandleCommand(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<LoginResultDto>();

            var user = await _userManager.FindByEmailAsync(request.Email);
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            try
            {
                await SendResetPasswordEmail(user, code);
                response.AddOkResult(Resources.User.ForgotPasswordSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.AddErrorResult(Resources.User.ForgotPasswordError);
            }

            return response;
        }

        public async Task SendResetPasswordEmail(ApplicationUser user, string code)
        {
            var email = WebUtility.UrlDecode(user.Email);
            var encoded = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var frontUrl = _configuration.GetValue<string>("SecurityOptions:FrontUrl");
            var frontUrlLogo = _configuration.GetValue<string>("SecurityOptions:FrontUrlLogo");
            var callbackUrl = $"{frontUrl}/user/reset-password?email={email}&code={encoded}";

            var emailDto = new SendEmailDto
            {
                EmailCode = Constants.Email.User.ResetPassword,
                ToEmails = new List<string> { user.Email ?? string.Empty },
                BodyParams = new Dictionary<string, string>
                {
                    { "{LOGO}", frontUrlLogo },
                    { "{USER}", user.FirstName! },
                    { "{LINK}", callbackUrl }
                }
            };

            await _mediator!.Send(new SendEmailCommand(emailDto));
        }
    }
}
