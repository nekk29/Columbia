using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class UpdateRelatedSampleCommand : CommandBase<GetRelatedSampleDto>
    {
        public UpdateRelatedSampleCommand(UpdateRelatedSampleDto updateDto) => UpdateDto = updateDto;
        public UpdateRelatedSampleDto UpdateDto { get; set; }
    }
}
