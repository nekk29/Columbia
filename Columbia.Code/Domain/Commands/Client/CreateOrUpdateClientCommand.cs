using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Client;

namespace $safesolutionname$.Domain.Commands.Client
{
    public class CreateOrUpdateClientCommand(CreateOrUpdateClientDto createDto) : CommandBase<CreateOrUpdateClientResultDto>
    {
        public CreateOrUpdateClientDto CreateDto { get; set; } = createDto;
    }
}
