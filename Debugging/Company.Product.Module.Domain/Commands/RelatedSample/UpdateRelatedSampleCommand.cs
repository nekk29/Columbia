using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class UpdateRelatedSampleCommand(UpdateRelatedSampleDto updateDto) : CommandBase<GetRelatedSampleDto>
    {
        public UpdateRelatedSampleDto UpdateDto { get; set; } = updateDto;
    }
}
