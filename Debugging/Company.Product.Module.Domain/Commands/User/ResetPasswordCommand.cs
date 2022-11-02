using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Commands.User
{
    public class ResetPasswordCommand : CommandBase
    {
        public ResetPasswordCommand(ResetPasswordDto resetPasswordDto) => ResetPasswordDto = resetPasswordDto;
        public ResetPasswordDto ResetPasswordDto { get; set; }
    }
}
