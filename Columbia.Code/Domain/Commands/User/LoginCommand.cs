using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Commands.User
{
    public class LoginCommand(LoginDto loginDto) : CommandBase<LoginResultDto>
    {
        public LoginDto LoginDto { get; set; } = loginDto;
    }
}
