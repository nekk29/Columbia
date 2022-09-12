using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class CreateRelatedSampleCommandValidator : CommandValidatorBase<CreateRelatedSampleCommand>
    {
        public CreateRelatedSampleCommandValidator()
        {
            RequiredInformation(x => x.CreateDto);
        }
    }
}
