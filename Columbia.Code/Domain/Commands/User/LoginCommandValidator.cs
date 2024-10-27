using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.User;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Commands.User
{
    public class LoginCommandValidator : CommandValidatorBase<LoginCommand>
    {
        private readonly UserManager<Entity.ApplicationUser> _userManager;
        private readonly IRepository<Entity.AspNetRole> _aspNetRoleRepository;
        private readonly IRepository<Entity.Application> _applicationRepository;

        public LoginCommandValidator(
            UserManager<Entity.ApplicationUser> userManager,
            IRepository<Entity.AspNetRole> aspNetRoleRepository,
            IRepository<Entity.Application> applicationRepository
        )
        {
            _userManager = userManager;
            _aspNetRoleRepository = aspNetRoleRepository;
            _applicationRepository = applicationRepository;

            RequiredInformation(x => x.LoginDto).DependentRules(() =>
            {
                RequiredField(x => x.LoginDto.ApplicationCode, Resources.User.NoAccessToApplication)
                    .DependentRules(() =>
                    {
                        RequiredString(x => x.LoginDto.UserName, Resources.User.UserName, default, 256)
                            .DependentRules(() =>
                            {
                                RuleFor(x => x.LoginDto.UserName)
                                    .MustAsync(ValidateExistenceAsync)
                                    .WithCustomValidationMessage()
                                    .DependentRules(() =>
                                    {
                                        RuleFor(x => x.LoginDto)
                                            .MustAsync(ValidateApplicationAccessAsync)
                                            .WithCustomValidationMessage();
                                    });
                            });
                    });
                RequiredString(x => x.LoginDto.Password, Resources.User.Password, default, 256);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(LoginCommand command, string? userName, ValidationContext<LoginCommand> context, CancellationToken cancellationToken)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName!);
            applicationUser ??= await _userManager.FindByEmailAsync(userName!);

            if (applicationUser == null)
                return CustomValidationMessage(context, Resources.User.UserDoesNotExist);

            if (!applicationUser.IsActive)
                return CustomValidationMessage(context, Resources.User.UserDisabled);

            return true;
        }

        protected async Task<bool> ValidateApplicationAccessAsync(LoginCommand command, LoginDto loginDto, ValidationContext<LoginCommand> context, CancellationToken cancellationToken)
        {
            var application = await _applicationRepository.GetByAsNoTrackingAsync(x => x.IsActive && x.Code == loginDto.ApplicationCode);
            if (application == null)
                return CustomValidationMessage(context, Resources.User.NoAccessToApplication);

            var applicationUser = await _userManager.FindByNameAsync(loginDto.UserName!);
            applicationUser ??= await _userManager.FindByEmailAsync(loginDto.UserName!);

            var roles = await _userManager.GetRolesAsync(applicationUser!);
            roles = await _aspNetRoleRepository
                .FindAllAsNoTracking()
                .Where(x => x.Application.IsActive && x.Application.Code == loginDto.ApplicationCode && roles.Contains(x.Name))
                .Select(x => x.Name)
                .ToListAsync(cancellationToken);

            if (!roles.Any())
                return CustomValidationMessage(context, Resources.User.NoAccessToApplication);

            return true;
        }
    }
}
