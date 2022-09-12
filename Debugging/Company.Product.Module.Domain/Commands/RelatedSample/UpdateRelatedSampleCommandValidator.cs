using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Repository.Abstractions.Base;
namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class UpdateRelatedSampleCommandValidator : CommandValidatorBase<UpdateRelatedSampleCommand>
    {
        private readonly IRepository<Entity.RelatedSample> _relatedSampleRepository;

        public UpdateRelatedSampleCommandValidator(IRepository<Entity.RelatedSample> relatedSampleRepository)
        {
            _relatedSampleRepository = relatedSampleRepository;

            RequiredInformation(x => x.UpdateDto)
                .DependentRules(() =>
                {
                    RuleFor(x => x.UpdateDto.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateRelatedSampleCommand command, Guid id, ValidationContext<UpdateRelatedSampleCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _relatedSampleRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
