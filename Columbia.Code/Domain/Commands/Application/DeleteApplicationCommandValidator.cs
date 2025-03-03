﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Commands.Application
{
    public class DeleteApplicationCommandValidator : CommandValidatorBase<DeleteApplicationCommand>
    {
        private readonly IRepository<Entity.Application> _applicationRepository;

        public DeleteApplicationCommandValidator(IRepository<Entity.Application> applicationRepository)
        {
            _applicationRepository = applicationRepository;

            RequiredField(x => x.Id, Resources.Common.IdentifierRequired)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteApplicationCommand command, Guid id, ValidationContext<DeleteApplicationCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _applicationRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
