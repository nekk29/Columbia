using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class CreateSampleCommand(CreateSampleDto createDto) : CommandBase<GetSampleDto>
    {
        public CreateSampleDto CreateDto { get; set; } = createDto;
    }
}
