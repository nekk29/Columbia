using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Action;

namespace $safesolutionname$.Domain.Commands.Action
{
    public class CreateActionCommand(CreateActionDto createDto) : CommandBase<GetActionDto>
    {
        public CreateActionDto CreateDto { get; set; } = createDto;
    }
}
