﻿using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Role;
using Company.Product.Module.Entity;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Company.Product.Module.Domain.Commands.Role
{
    public class CreateRoleCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IMediator mediator,
        RoleManager<ApplicationRole> roleManager,
        CreateRoleCommandValidator validator,
        IRepository<ApplicationRole> applicationRoleRepository
    ) : CommandHandlerBase<CreateRoleCommand, GetRoleDto>(unitOfWork, mapper, mediator, validator)
    {
        protected override bool UseTransaction => false;

        public override async Task<ResponseDto<GetRoleDto>> HandleCommand(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRoleDto>();
            var applicationRole = _mapper?.Map<ApplicationRole>(request.CreateDto);

            if (applicationRole != null)
            {
                applicationRoleRepository.UpdateAuditTrails(applicationRole);

                var result = await roleManager.CreateAsync(applicationRole);

                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(e =>
                    {
                        response.AddErrorResult($"{e.Code}: {e.Description}");
                    });

                    return response;
                }
            }

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            var getroleDto = _mapper?.Map<GetRoleDto>(applicationRole);
            if (getroleDto != null) response.UpdateData(getroleDto);

            return response;
        }
    }
}
