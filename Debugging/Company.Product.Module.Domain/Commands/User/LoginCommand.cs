using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Commands.User
{
    public class LoginCommand : CommandBase<LoginResultDto>
    {
        public LoginCommand(LoginDto loginDto) => LoginDto = loginDto;
        public LoginDto LoginDto { get; set; }
    }
}
