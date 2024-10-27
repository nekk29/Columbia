using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.MenuOption;

namespace Company.Product.Module.Domain.Commands.MenuOption
{
    public class UpdateMenuOptionCommand(UpdateMenuOptionDto updateDto) : CommandBase<GetMenuOptionDto>
    {
        public UpdateMenuOptionDto UpdateDto { get; set; } = updateDto;
    }
}
