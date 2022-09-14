using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class DeleteSampleCommandValidator : CommandValidatorBase<DeleteSampleCommand>
    {
        private readonly IRepository<Entity.Sample> _sampleRepository;

        public DeleteSampleCommandValidator(IRepository<Entity.Sample> sampleRepository)
        {
            _sampleRepository = sampleRepository;

            RequiredField(x => x.Id, Resources.Common.IdentifierRequired)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteSampleCommand command, Guid id, ValidationContext<DeleteSampleCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _sampleRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
