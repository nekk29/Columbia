using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Commands.User
{
    public class ResetPasswordCommand(ResetPasswordDto resetPasswordDto) : CommandBase
    {
        public ResetPasswordDto ResetPasswordDto { get; set; } = resetPasswordDto;
    }
}
