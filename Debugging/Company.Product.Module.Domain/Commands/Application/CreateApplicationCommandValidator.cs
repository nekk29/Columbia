using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Application
{
    public class CreateApplicationCommandValidator : CommandValidatorBase<CreateApplicationCommand>
    {
        public CreateApplicationCommandValidator()
        {
            RequiredInformation(x => x.CreateDto)
                .DependentRules(() =>
                {
                    //RequiredString(x => x.CreateDto.Code, Resources.Application.Code, {Min}, {Max});
                    //RequiredString(x => x.CreateDto.Name, Resources.Application.Name, {Min}, {Max});
                });
        }
    }
}
