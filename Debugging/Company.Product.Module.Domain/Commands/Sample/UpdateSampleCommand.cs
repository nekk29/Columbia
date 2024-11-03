using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class UpdateSampleCommand(UpdateSampleDto updateDto) : CommandBase<GetSampleDto>
    {
        public UpdateSampleDto UpdateDto { get; set; } = updateDto;
    }
}
