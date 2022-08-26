using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.User
{
    public class LoginCommandValidator : CommandValidatorBase<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RequiredInformation(x => x.LoginDto).DependentRules(() =>
            {
                RequiredString(x => x.LoginDto.UserName, Resources.User.UserName, 6, 255);
                RequiredString(x => x.LoginDto.Password, Resources.User.Password, 2, 100);
            });
        }
    }
}
