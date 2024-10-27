using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Client
{
    public class CreateOrUpdateClientCommandValidator : CommandValidatorBase<CreateOrUpdateClientCommand>
    {
        public CreateOrUpdateClientCommandValidator()
        {

            RequiredField(x => x.CreateDto.ApplicationCode, Resources.Client.ApplicationCode);
            RequiredField(x => x.CreateDto.ApplicationUri, Resources.Client.ApplicationUri);
        }
    }
}
