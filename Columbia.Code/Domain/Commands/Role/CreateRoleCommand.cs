using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Domain.Commands.Role
{
    public class CreateRoleCommand(CreateRoleDto createDto) : CommandBase<GetRoleDto>
    {
        public CreateRoleDto CreateDto { get; set; } = createDto;
    }
}
