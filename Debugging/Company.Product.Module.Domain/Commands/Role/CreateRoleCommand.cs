using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Role;

namespace Company.Product.Module.Domain.Commands.Role
{
    public class CreateRoleCommand(CreateRoleDto createDto) : CommandBase<GetRoleDto>
    {
        public CreateRoleDto CreateDto { get; set; } = createDto;
    }
}
