using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Commands.User
{
    public class CreateUserCommand(CreateUserDto createDto) : CommandBase<GetUserDto>
    {
        public CreateUserDto CreateDto { get; set; } = createDto;
    }
}
