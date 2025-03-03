﻿using FluentValidation;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Role;
using $safesolutionname$.Entity;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Commands.Role
{
    public class CreateRoleCommandValidator : CommandValidatorBase<CreateRoleCommand>
    {
        private readonly IRepository<AspNetRole> _roleRepository;

        public CreateRoleCommandValidator(IRepository<AspNetRole> roleRepository)
        {
            _roleRepository = roleRepository;

            RequiredInformation(x => x.CreateDto)
                .DependentRules(() =>
                {
                    RequiredString(x => x.CreateDto.Name, Resources.Role.Name, 2, 100);
                })
                .DependentRules(() =>
                {
                    RuleFor(x => x.CreateDto)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(CreateRoleCommand command, CreateRoleDto createDto, ValidationContext<CreateRoleCommand> context, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByAsNoTrackingAsync(x => x.Name == createDto.Name && x.IsActive);
            if (role != null) return CustomValidationMessage(context, Resources.Common.DuplicateRecord);
            return true;
        }
    }
}
