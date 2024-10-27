using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Application;

namespace $safesolutionname$.Domain.Commands.Application
{
    public class UpdateApplicationCommand(UpdateApplicationDto updateDto) : CommandBase<GetApplicationDto>
    {
        public UpdateApplicationDto UpdateDto { get; set; } = updateDto;
    }
}
