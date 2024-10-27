using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Module;

namespace $safesolutionname$.Domain.Commands.Module
{
    public class UpdateModuleCommand(UpdateModuleDto updateDto) : CommandBase<GetModuleDto>
    {
        public UpdateModuleDto UpdateDto { get; set; } = updateDto;
    }
}
