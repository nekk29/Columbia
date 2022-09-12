using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class CreateSampleCommand : CommandBase<GetSampleDto>
    {
        public CreateSampleCommand(CreateSampleDto createDto) => CreateDto = createDto;
        public CreateSampleDto CreateDto { get; set; }
    }
}
