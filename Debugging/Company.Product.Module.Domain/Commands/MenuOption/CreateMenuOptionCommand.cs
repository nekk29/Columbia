using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.MenuOption;

namespace Company.Product.Module.Domain.Commands.MenuOption
{
    public class CreateMenuOptionCommand(CreateMenuOptionDto createDto) : CommandBase<GetMenuOptionDto>
    {
        public CreateMenuOptionDto CreateDto { get; set; } = createDto;
    }
}
