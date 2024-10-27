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
                .DependentRules(() => {
                    //RequiredField(x => x.UpdateDto.Id, Resources.Common.IdentifierRequired);
                    //RequiredField(x => x.UpdateDto.RelatedId, Resources.Sample.RelatedId);
                    //RequiredString(x => x.UpdateDto.Code, Resources.Sample.Code, {Min}, {Max});
                    //RequiredString(x => x.UpdateDto.Description, Resources.Sample.Description, {Min}, {Max});
                }).DependentRules(() =>
                {
                    RuleFor(x => x.UpdateDto.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }


        protected async Task<bool> ValidateExistenceAsync(UpdateSampleCommand command, Guid id, ValidationContext<UpdateSampleCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _sampleRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
