﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using $safesolutionname$.Common;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Domain.Commands.Email;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Email;
using $safesolutionname$.Dto.User;
using $safesolutionname$.Entity;
using $safesolutionname$.Repository.Abstractions.Transactions;
using System.Net;
using System.Text;

namespace $safesolutionname$.Domain.Commands.User
{
    public class ForgotPasswordCommandHandler : CommandHandlerBase<ForgotPasswordCommand>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public ForgotPasswordCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            ForgotPasswordCommandValidator validator,
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager
        ) : base(unitOfWork, mapper, mediator, validator)
        {
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
