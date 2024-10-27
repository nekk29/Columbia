using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.Domain.Commands.MenuOption
{
    public class UpdateMenuOptionCommand(UpdateMenuOptionDto updateDto) : CommandBase<GetMenuOptionDto>
    {
        public UpdateMenuOptionDto UpdateDto { get; set; } = updateDto;
    }
}
