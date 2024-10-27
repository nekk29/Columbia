using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Action;

namespace $safesolutionname$.Domain.Commands.Action
{
    public class UpdateActionCommand(UpdateActionDto updateDto) : CommandBase<GetActionDto>
    {
        public UpdateActionDto UpdateDto { get; set; } = updateDto;
    }
}
