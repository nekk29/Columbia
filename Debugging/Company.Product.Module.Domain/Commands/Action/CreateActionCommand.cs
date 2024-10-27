using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Action;

namespace Company.Product.Module.Domain.Commands.Action
{
    public class CreateActionCommand(CreateActionDto createDto) : CommandBase<GetActionDto>
    {
        public CreateActionDto CreateDto { get; set; } = createDto;
    }
}
