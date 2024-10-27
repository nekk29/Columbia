using FluentValidation;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Command.Permission
{
    public class AssignPermissionsCommandValidator : CommandValidatorBase<AssignPermissionsCommand>
    {
        private readonly IRepository<Entity.AspNetRole> _roleRepository;
        private readonly IRepository<Entity.Action> _actionRepository;

        public AssignPermissionsCommandValidator(IRepository<Entity.AspNetRole> roleRepository, IRepository<Entity.Action> actionRepository)
        {
            _roleRepository = roleRepository;
            _actionRepository = actionRepository;

            RequiredField(x => x.RoleId, Resources.Role.RoleId)
                .DependentRules(() =>
                {
                    RuleFor(x => x.RoleId)
                        .MustAsync(ValidateRoleExistenceAsync)
                        .WithCustomValidationMessage();
                });

            RequiredField(x => x.ActionIds, Resources.Action.ActionId)
                .DependentRules(() =>
                {
                    RuleFor(x => x.ActionIds)
                        .MustAsync(ValidateActionsExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateRoleExistenceAsync(AssignPermissionsCommand command, Guid id, ValidationContext<AssignPermissionsCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _roleRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Role.RoleDoesNotExist);
            return true;
        }

        protected async Task<bool> ValidateActionsExistenceAsync(AssignPermissionsCommand command, IEnumerable<Guid> actionIds, ValidationContext<AssignPermissionsCommand> context, CancellationToken cancellationToken)
        {
            var uniqueActionIds = actionIds.Distinct();

            var actionsCount = await _actionRepository
                .FindAll()
                .Where(x => uniqueActionIds.Contains(x.Id) && x.IsActive)
                .CountAsync(cancellationToken);

            if (actionsCount < uniqueActionIds.Count())
                return CustomValidationMessage(context, Resources.Action.ActionDoesNotExist);

            return true;
        }
    }
}
