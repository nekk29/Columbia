using FluentValidation;
using $safesolutionname$.Domain.Commands.Base;
using Microsoft.AspNetCore.Identity;

namespace $safesolutionname$.Domain.Commands.User
{
    public class LoginCommandValidator : CommandValidatorBase<LoginCommand>
    {
        private readonly UserManager<Entity.ApplicationUser> _userManager;

        public LoginCommandValidator(UserManager<Entity.ApplicationUser> userManager)
        {
            _userManager = userManager;

            RequiredInformation(x => x.LoginDto).DependentRules(() =>
            {
                RequiredString(x => x.LoginDto.UserName, Resources.User.UserName, default, 256)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.LoginDto.UserName)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                RequiredString(x => x.LoginDto.Password, Resources.User.Password, default, 256);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(LoginCommand command, string? userName, ValidationContext<LoginCommand> context, CancellationToken cancellationToken)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName);

            if (applicationUser == null)
                applicationUser = await _userManager.FindByEmailAsync(userName);

            if (applicationUser == null)
                return CustomValidationMessage(context, Resources.User.UserDoesNotExist);

            if (!applicationUser.IsActive)
                return CustomValidationMessage(context, Resources.User.UserDisabled);

            return true;
        }
    }
}
