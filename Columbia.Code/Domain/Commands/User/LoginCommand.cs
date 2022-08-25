using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Commands.User
{
    public class LoginCommand : CommandBase<LoginResultDto>
    {
        public LoginCommand(LoginDto loginDto) => LoginDto = loginDto;
        public LoginDto LoginDto { get; set; }
    }
}
