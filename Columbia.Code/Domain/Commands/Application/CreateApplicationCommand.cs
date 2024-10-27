using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Application;

namespace $safesolutionname$.Domain.Commands.Application
{
    public class CreateApplicationCommand(CreateApplicationDto createDto) : CommandBase<GetApplicationDto>
    {
        public CreateApplicationDto CreateDto { get; set; } = createDto;
    }
}
