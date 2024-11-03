using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class CreateRelatedSampleCommand(CreateRelatedSampleDto createDto) : CommandBase<GetRelatedSampleDto>
    {
        public CreateRelatedSampleDto CreateDto { get; set; } = createDto;
    }
}
