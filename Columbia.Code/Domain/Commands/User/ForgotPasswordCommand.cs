using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Commands.User
{
    public class ForgotPasswordCommand(ForgotPasswordDto forgotPasswordDto) : CommandBase
    {
        public ForgotPasswordDto ForgotPasswordDto { get; set; } = forgotPasswordDto;
    }
}
