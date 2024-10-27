using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Commands.User
{
    public class LoginCommand(LoginDto loginDto) : CommandBase<LoginResultDto>
    {
        public LoginDto LoginDto { get; set; } = loginDto;
    }
}
