using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Repository.Abstractions.Base;
namespace Company.Product.Module.Domain.Commands.Sample
{
    public class UpdateSampleCommandValidator : CommandValidatorBase<UpdateSampleCommand>
    {
        private readonly IRepository<Entity.Sample> _sampleRepository;

        public UpdateSampleCommandValidator(IRepository<Entity.Sample> sampleRepository)
        {
            _sampleRepository = sampleRepository;

            RequiredInformation(x => x.UpdateDto)
                .DependentRules(() =>
                {
                    RuleFor(x => x.UpdateDto.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateSampleCommand command, Guid id, ValidationContext<UpdateSampleCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _sampleRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
