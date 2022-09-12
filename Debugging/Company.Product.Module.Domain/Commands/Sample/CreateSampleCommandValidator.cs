using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class CreateSampleCommandValidator : CommandValidatorBase<CreateSampleCommand>
    {
        public CreateSampleCommandValidator()
        {
            RequiredInformation(x => x.CreateDto);
        }
    }
}
