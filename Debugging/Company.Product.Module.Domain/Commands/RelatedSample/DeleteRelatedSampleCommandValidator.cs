using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class DeleteRelatedSampleCommandValidator : CommandValidatorBase<DeleteRelatedSampleCommand>
    {
        private readonly IRepository<Entity.RelatedSample> _relatedSampleRepository;

        public DeleteRelatedSampleCommandValidator(IRepository<Entity.RelatedSample> relatedSampleRepository)
        {
            _relatedSampleRepository = relatedSampleRepository;

            RequiredField(x => x.Id, Resources.Common.IdentifierRequired)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteRelatedSampleCommand command, Guid id, ValidationContext<DeleteRelatedSampleCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _relatedSampleRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
