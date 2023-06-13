using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Entity;
using Company.Product.Module.Repository.Abstractions.Base;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Commands.Role
{
    public class DeleteRoleCommandValidator : CommandValidatorBase<DeleteRoleCommand>
    {
        private readonly IRepository<AspNetRole> _roleRepository;

        public DeleteRoleCommandValidator(IRepository<AspNetRole> roleRepository)
        {
            _roleRepository = roleRepository;

            RequiredField(x => x.Id, Resources.Common.IdentifierRequired)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteRoleCommand command, Guid id, ValidationContext<DeleteRoleCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _roleRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
