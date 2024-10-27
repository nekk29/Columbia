﻿using AutoMapper;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.Role
{
    public class GetRoleQueryHandler(
        IMapper mapper,
        IRepository<Entity.AspNetRole> roleRepository
    ) : QueryHandlerBase<GetRoleQuery, GetRoleDto>(mapper)
    {
        protected override async Task<ResponseDto<GetRoleDto>> HandleQuery(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRoleDto>();
            var role = await roleRepository.GetByAsync(x => x.Id == request.Id, x => x.Application);
            var roleDto = _mapper?.Map<GetRoleDto>(role);
            response.UpdateData(roleDto!);
            return await Task.FromResult(response);
        }
    }
}
