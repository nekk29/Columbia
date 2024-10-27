using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Module;

namespace Company.Product.Module.Domain.Commands.Module
{
    public class UpdateModuleCommand(UpdateModuleDto updateDto) : CommandBase<GetModuleDto>
    {
        public UpdateModuleDto UpdateDto { get; set; } = updateDto;
    }
}
