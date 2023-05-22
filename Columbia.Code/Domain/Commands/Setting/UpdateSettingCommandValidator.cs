﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Setting;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Commands.Setting
{
    public class UpdateSettingCommandValidator : CommandValidatorBase<UpdateSettingCommand>
    {
        private readonly IRepository<Entity.Setting> _settingRepository;

        public UpdateSettingCommandValidator(IRepository<Entity.Setting> settingRepository)
        {
            _settingRepository = settingRepository;

            RequiredInformation(x => x.UpdateDto)
                .DependentRules(() =>
                {
                    RuleFor(x => x.UpdateDto)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }


        protected async Task<bool> ValidateExistenceAsync(UpdateSettingCommand command, UpdateSettingDto dto, ValidationContext<UpdateSettingCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _settingRepository.FindAll().Where(x => x.Group == dto.Group && x.Code == dto.Code).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
