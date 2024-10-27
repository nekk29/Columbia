using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Role;

namespace Company.Product.Module.Domain.Commands.Role
{
    public class UpdateRoleCommand(UpdateRoleDto updateDto) : CommandBase<GetRoleDto>
    {
        public UpdateRoleDto UpdateDto { get; set; } = updateDto;
    }
}
