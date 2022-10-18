using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Commands.User
{
    public class UpdateUserCommand : CommandBase<GetUserDto>
    {
        public UpdateUserCommand(UpdateUserDto updateDto) => UpdateDto = updateDto;
        public UpdateUserDto UpdateDto { get; set; }
    }
}
