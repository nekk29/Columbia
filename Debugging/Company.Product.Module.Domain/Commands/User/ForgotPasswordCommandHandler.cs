using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using Company.Product.Module.EmailClient;
using Company.Product.Module.Entity;
using Company.Product.Module.Repository.Abstractions.Transactions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text;

namespace Company.Product.Module.Domain.Commands.User
{
    public class ForgotPasswordCommandHandler : CommandHandlerBase<ForgotPasswordCommand>
    {
        private readonly IEmailClient _emailClient;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public ForgotPasswordCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            ForgotPasswordCommandValidator validator,
            IEmailClient emailClient,
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _emailClient = emailClient;
            _configuration = configuration;
            _userManager = userManager;
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
                response.AddErrorResult($"{Resources.User.ForgotPasswordError}: {ex.Message}");
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
            var emailBody = Resources.User.ResetPasswordEmail;

            emailBody = emailBody.Replace("{LOGO}", frontUrlLogo);
            emailBody = emailBody.Replace("{USER}", user.FirstName);
            emailBody = emailBody.Replace("{LINK}", callbackUrl);

            await _emailClient.SendEmailAsync(
                user.Email ?? string.Empty,
                Resources.User.ResetPasswordSubject,
                emailBody,
                true
            );
        }
    }
}
