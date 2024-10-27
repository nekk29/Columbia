using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Module;

namespace Company.Product.Module.Domain.Commands.Module
{
    public class CreateModuleCommand(CreateModuleDto createDto) : CommandBase<GetModuleDto>
    {
        public CreateModuleDto CreateDto { get; set; } = createDto;
    }
}
