using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Module;

namespace $safesolutionname$.Domain.Commands.Module
{
    public class CreateModuleCommand(CreateModuleDto createDto) : CommandBase<GetModuleDto>
    {
        public CreateModuleDto CreateDto { get; set; } = createDto;
    }
}
