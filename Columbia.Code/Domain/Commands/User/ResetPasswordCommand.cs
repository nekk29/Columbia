using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Commands.User
{
    public class ResetPasswordCommand(ResetPasswordDto resetPasswordDto) : CommandBase
    {
        public ResetPasswordDto ResetPasswordDto { get; set; } = resetPasswordDto;
    }
}
