using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Domain.Commands.Role
{
    public class UpdateRoleCommand : CommandBase<GetRoleDto>
    {
        public UpdateRoleCommand(UpdateRoleDto updateDto) => UpdateDto = updateDto;
        public UpdateRoleDto UpdateDto { get; set; }
    }
}
