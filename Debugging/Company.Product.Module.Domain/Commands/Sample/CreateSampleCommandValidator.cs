using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class CreateSampleCommandValidator : CommandValidatorBase<CreateSampleCommand>
    {
        public CreateSampleCommandValidator()
        {
            RequiredInformation(x => x.CreateDto)
                .DependentRules(() =>
                {
                    //RequiredField(x => x.CreateDto.RelatedSampleId, Resources.Sample.RelatedSampleId);
                    //RequiredString(x => x.CreateDto.Code, Resources.Sample.Code, {Min}, {Max});
                    //RequiredString(x => x.CreateDto.Description, Resources.Sample.Description, {Min}, {Max});
                });
        }
    }
}
