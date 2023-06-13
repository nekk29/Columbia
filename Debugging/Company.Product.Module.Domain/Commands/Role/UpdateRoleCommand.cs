using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Role;

namespace Company.Product.Module.Domain.Commands.Role
{
    public class UpdateRoleCommand : CommandBase<GetRoleDto>
    {
        public UpdateRoleCommand(UpdateRoleDto updateDto) => UpdateDto = updateDto;
        public UpdateRoleDto UpdateDto { get; set; }
    }
}
