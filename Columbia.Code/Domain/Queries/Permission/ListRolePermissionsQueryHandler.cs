using AutoMapper;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Permission;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.Permission
{
    public class ListRolePermissionsQueryHandler(
        IMapper mapper,
        IRepository<Entity.Action> actionRepository,
        IRepository<Entity.AspNetRole> aspNetRoleRepository,
        IRepository<Entity.Permission> permissionRepository
    ) : QueryHandlerBase<ListRolePermissionsQuery, IEnumerable<ListRolePermissionDto>>(mapper)
    {
        protected override async Task<ResponseDto<IEnumerable<ListRolePermissionDto>>> HandleQuery(ListRolePermissionsQuery request, CancellationToken cancellationToken)
        {
            var rolePermissionDtos = new List<ListRolePermissionDto>();
            var response = new ResponseDto<IEnumerable<ListRolePermissionDto>>();

            var role = await aspNetRoleRepository.GetByAsNoTrackingAsync(x => x.Id == request.RoleId);
            if (role == null)
            {
                response.UpdateData(rolePermissionDtos);
                return response;
            }

            var actions = await actionRepository.FindByAsync(
                x => x.Module.ApplicationId == role.ApplicationId,
                x => x.Module
            );

            var permissions = await permissionRepository.FindByAsNoTrackingAsync(
                x => x.RoleId == role.Id && x.IsActive
            );

            foreach (var action in actions)
            {
                var rolePermissionDto = rolePermissionDtos.FirstOrDefault(x => x.ModuleCode == action.Module.Code);
                if (rolePermissionDto != null) continue;

                rolePermissionDto ??= new ListRolePermissionDto
                {
                    ModuleCode = action.Module.Code,
                    ModuleName = action.Module.Name
                };

                rolePermissionDto.Permissions = actions
                    .Where(x => x.Module.Code == action.Module.Code)
                    .Select(x => new ListPermissionDto
                    {
                        RoleId = role.Id,
                        RoleName = role.Name!,
                        ModuleCode = x.Module?.Code!,
                        ModuleName = x.Module?.Name!,
                        ParentActionId = x.ParentActionId,
                        ActionId = x.Id,
                        ActionCode = x.Code,
                        ActionName = x.Name,
                        IsAssigned = permissions.Any(p => p.ActionId == x.Id)
                    });

                rolePermissionDto.Permissions = rolePermissionDto.Permissions
                    .OrderBy(x => x.ActionCode)
                    .ToList();

                rolePermissionDtos.Add(rolePermissionDto);
            }

            rolePermissionDtos = [.. rolePermissionDtos.OrderBy(x => x.ModuleName)];

            response.UpdateData(rolePermissionDtos);

            return response;
        }
    }
}
