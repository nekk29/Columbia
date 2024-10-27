﻿using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Action
{
    public class CreateActionCommandValidator : CommandValidatorBase<CreateActionCommand>
    {
        public CreateActionCommandValidator()
        {
            RequiredInformation(x => x.CreateDto)
                .DependentRules(() =>
                {
                    //RequiredField(x => x.CreateDto.ModuleId, Resources.Action.ModuleId);
                    //RequiredString(x => x.CreateDto.Code, Resources.Action.Code, {Min}, {Max});
                    //RequiredString(x => x.CreateDto.Name, Resources.Action.Name, {Min}, {Max});
                });
        }
    }
}
