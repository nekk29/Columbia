using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.MenuOption
{
    public class CreateMenuOptionCommandValidator : CommandValidatorBase<CreateMenuOptionCommand>
    {
        public CreateMenuOptionCommandValidator()
        {
            RequiredInformation(x => x.CreateDto)
                .DependentRules(() =>
                {
                    //RequiredField(x => x.CreateDto.ApplicationId, Resources.MenuOption.ApplicationId);
                    //RequiredField(x => x.CreateDto.ActionId, Resources.MenuOption.ActionId);
                    //RequiredString(x => x.CreateDto.Code, Resources.MenuOption.Code, {Min}, {Max});
                    //RequiredString(x => x.CreateDto.Name, Resources.MenuOption.Name, {Min}, {Max});
                    //RequiredField(x => x.CreateDto.SortOrder, Resources.MenuOption.SortOrder);
                });
        }
    }
}
