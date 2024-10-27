using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Domain.Commands.Role
{
    public class UpdateRoleCommand(UpdateRoleDto updateDto) : CommandBase<GetRoleDto>
    {
        public UpdateRoleDto UpdateDto { get; set; } = updateDto;
    }
}
