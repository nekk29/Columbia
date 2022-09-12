using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class CreateRelatedSampleCommand : CommandBase<GetRelatedSampleDto>
    {
        public CreateRelatedSampleCommand(CreateRelatedSampleDto createDto) => CreateDto = createDto;
        public CreateRelatedSampleDto CreateDto { get; set; }
    }
}
