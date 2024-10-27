using System.Text;
using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using Company.Product.Module.Entity;
using Company.Product.Module.Repository.Abstractions.Transactions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace Company.Product.Module.Domain.Commands.User
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
