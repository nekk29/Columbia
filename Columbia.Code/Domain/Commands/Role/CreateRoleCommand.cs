using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Domain.Commands.Role
{
    public class CreateRoleCommand : CommandBase<GetRoleDto>
    {
        public CreateRoleCommand(CreateRoleDto createDto) => CreateDto = createDto;
        public CreateRoleDto CreateDto { get; set; }
    }
}
