﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using $safesolutionname$.Entity;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.User
{
    public class ResetPasswordCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IMediator mediator,
        ResetPasswordCommandValidator validator,
        UserManager<ApplicationUser> userManager
    ) : CommandHandlerBase<ResetPasswordCommand>(unitOfWork, mapper, mediator, validator)
    {
        public override async Task<ResponseDto> HandleCommand(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<LoginResultDto>();

            var user = await userManager.FindByEmailAsync(request.ResetPasswordDto.Email);
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.ResetPasswordDto.Code));
            var result = await userManager.ResetPasswordAsync(user!, code, request.ResetPasswordDto.Password!);

            if (result.Succeeded)
                response.AddOkResult(Resources.User.ResetPasswordSuccess);
            else
            {
                var errors = string.Join(Environment.NewLine, result.Errors.Select(x => x.Description));
                response.AddErrorResult($"{Resources.User.ResetPasswordError}: {Environment.NewLine}{errors}");
            }

            return response;
        }
    }
}
