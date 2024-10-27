using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Action;

namespace Company.Product.Module.Domain.Commands.Action
{
    public class UpdateActionCommand(UpdateActionDto updateDto) : CommandBase<GetActionDto>
    {
        public UpdateActionDto UpdateDto { get; set; } = updateDto;
    }
}
