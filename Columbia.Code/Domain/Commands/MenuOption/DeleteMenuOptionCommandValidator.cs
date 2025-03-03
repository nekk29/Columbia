﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Commands.MenuOption
{
    public class DeleteMenuOptionCommandValidator : CommandValidatorBase<DeleteMenuOptionCommand>
    {
        private readonly IRepository<Entity.MenuOption> _menuOptionRepository;

        public DeleteMenuOptionCommandValidator(IRepository<Entity.MenuOption> menuOptionRepository)
        {
            _menuOptionRepository = menuOptionRepository;

            RequiredField(x => x.Id, Resources.Common.IdentifierRequired)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteMenuOptionCommand command, Guid id, ValidationContext<DeleteMenuOptionCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _menuOptionRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
