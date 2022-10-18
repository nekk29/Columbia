using FluentValidation;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Commands.User
{
    public class DeleteUserCommandValidator : CommandValidatorBase<DeleteUserCommand>
    {
        private readonly IRepository<Entity.AspNetUser> _userRepository;

        public DeleteUserCommandValidator(IRepository<Entity.AspNetUser> userRepository)
        {
            _userRepository = userRepository;

            RequiredField(x => x.Id, Resources.Common.IdentifierRequired)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteUserCommand command, Guid id, ValidationContext<DeleteUserCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _userRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
