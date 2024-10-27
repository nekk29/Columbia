﻿using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Commands.Application
{
    public class UpdateApplicationCommandValidator : CommandValidatorBase<UpdateApplicationCommand>
    {
        private readonly IRepository<Entity.Application> _applicationRepository;

        public UpdateApplicationCommandValidator(IRepository<Entity.Application> applicationRepository)
        {
            _applicationRepository = applicationRepository;

            RequiredInformation(x => x.UpdateDto)
                .DependentRules(() =>
                {
                    //RequiredField(x => x.UpdateDto.Id, Resources.Common.IdentifierRequired);
                    //RequiredString(x => x.UpdateDto.Code, Resources.Application.Code, {Min}, {Max});
                    //RequiredString(x => x.UpdateDto.Name, Resources.Application.Name, {Min}, {Max});
                }).DependentRules(() =>
                {
                    RuleFor(x => x.UpdateDto.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateApplicationCommand command, Guid id, ValidationContext<UpdateApplicationCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _applicationRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
