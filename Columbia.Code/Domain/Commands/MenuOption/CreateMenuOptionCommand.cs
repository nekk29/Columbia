using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.Domain.Commands.MenuOption
{
    public class CreateMenuOptionCommand(CreateMenuOptionDto createDto) : CommandBase<GetMenuOptionDto>
    {
        public CreateMenuOptionDto CreateDto { get; set; } = createDto;
    }
}
