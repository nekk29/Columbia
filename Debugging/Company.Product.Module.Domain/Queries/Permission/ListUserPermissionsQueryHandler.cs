using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Permission;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Queries.Permission
{
    public class ListUserPermissionsQueryHandler(
        IMapper mapper,
        IUserIdentity userIdentity,
        UserManager<Entity.ApplicationUser> userManager,
        IRepository<Entity.AspNetRole> aspNetRoleRepository,
        IRepository<Entity.Permission> permissionRepository
    ) : QueryHandlerBase<ListUserPermissionsQuery, IEnumerable<ListPermissionDto>>(mapper)
    {
        protected override async Task<ResponseDto<IEnumerable<ListPermissionDto>>> HandleQuery(ListUserPermissionsQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListPermissionDto>>();

            var user = await userManager.FindByNameAsync(userIdentity.GetCurrentUser());
            if (user == null)
            {
                response.UpdateData(new List<ListPermissionDto>());
                return response;
            }

            var roles = await userManager.GetRolesAsync(user);
            roles = await aspNetRoleRepository
                .FindAllAsNoTracking()
                .Where(x => x.Application.IsActive && x.Application.Code == request.ApplicationCode && roles.Contains(x.Name))
                .Select(x => x.Name)
                .ToListAsync(cancellationToken);

            var permissions = await permissionRepository.FindByAsNoTrackingAsync(
                x => x.IsActive && x.Action.IsActive && x.Role.IsActive && roles.Contains(x.Role.Name),
                x => x.Action.Module,
                x => x.Role
            );

            var permissionDtos = _mapper!.Map<IEnumerable<ListPermissionDto>>(permissions);

            foreach (var permissionDto in permissionDtos) permissionDto.IsAssigned = true;

            response.UpdateData(permissionDtos);

            return response;
        }
    }
}
