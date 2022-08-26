using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Commands.User
{
    public class CreateUserCommand : CommandBase<GetUserDto>
    {
        public CreateUserCommand(CreateUserDto createDto) => CreateDto = createDto;
        public CreateUserDto CreateDto { get; set; }
    }
}
