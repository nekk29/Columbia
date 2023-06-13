using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Role;

namespace Company.Product.Module.Domain.Commands.Role
{
    public class CreateRoleCommand : CommandBase<GetRoleDto>
    {
        public CreateRoleCommand(CreateRoleDto createDto) => CreateDto = createDto;
        public CreateRoleDto CreateDto { get; set; }
    }
}
