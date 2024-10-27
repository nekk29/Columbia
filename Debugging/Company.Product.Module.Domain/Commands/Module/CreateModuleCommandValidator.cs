﻿using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Module
{
    public class CreateModuleCommandValidator : CommandValidatorBase<CreateModuleCommand>
    {
        public CreateModuleCommandValidator()
        {
            RequiredInformation(x => x.CreateDto)
                .DependentRules(() =>
                {
                    //RequiredField(x => x.CreateDto.ApplicationId, Resources.Module.ApplicationId);
                    //RequiredString(x => x.CreateDto.Code, Resources.Module.Code, {Min}, {Max});
                    //RequiredString(x => x.CreateDto.Name, Resources.Module.Name, {Min}, {Max});
                });
        }
    }
}
