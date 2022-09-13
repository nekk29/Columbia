using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class CreateRelatedSampleCommandValidator : CommandValidatorBase<CreateRelatedSampleCommand>
    {
        public CreateRelatedSampleCommandValidator()
        {
            RequiredInformation(x => x.CreateDto)
                .DependentRules(() =>
                {
                    //RequiredString(x => x.CreateDto.Code, Resources.RelatedSample.Code, {Min}, {Max});
                    //RequiredString(x => x.CreateDto.Description, Resources.RelatedSample.Description, {Min}, {Max});
                });
        }
    }
}
