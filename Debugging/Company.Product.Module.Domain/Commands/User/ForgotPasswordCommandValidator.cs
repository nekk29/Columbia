using Company.Product.Module.Domain.Commands.Base;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Company.Product.Module.Domain.Commands.User
{
    public class ForgotPasswordCommandValidator : CommandValidatorBase<ForgotPasswordCommand>
    {
        private readonly UserManager<Entity.ApplicationUser> _userManager;

        public ForgotPasswordCommandValidator(UserManager<Entity.ApplicationUser> userManager)
        {
            _userManager = userManager;

            RequiredString(x => x.Email, Resources.User.Email, default, 256)
                .DependentRules(() =>
                {
                    ValidMail(x => x.Email, Resources.User.Email)
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.Email)
                                .MustAsync(ValidateExistenceAsync)
                                .WithCustomValidationMessage();
                        });
                });
        }

        protected async Task<bool> ValidateExistenceAsync(ForgotPasswordCommand command, string email, ValidationContext<ForgotPasswordCommand> context, CancellationToken cancellationToken)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);

            if (applicationUser == null)
                return CustomValidationMessage(context, Resources.User.UserDoesNotExist);

            if (!applicationUser.IsActive)
                return CustomValidationMessage(context, Resources.User.UserDisabled);

            return true;
        }
    }
}
