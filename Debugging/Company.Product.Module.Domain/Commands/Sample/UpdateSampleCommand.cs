using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class UpdateSampleCommand : CommandBase<GetSampleDto>
    {
        public UpdateSampleCommand(UpdateSampleDto updateDto) => UpdateDto = updateDto;
        public UpdateSampleDto UpdateDto { get; set; }
    }
}
