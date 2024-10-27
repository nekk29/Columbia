using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Permission;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Security;
using Microsoft.AspNetCore.Identity;

namespace Company.Product.Module.Domain.Queries.Permission
{
    public class ListPermissionQueryHandler(
        IMapper mapper,
        IUserIdentity userIdentity,
        UserManager<Entity.ApplicationUser> userManager,
        IRepository<Entity.Permission> permissionRepository
    ) : QueryHandlerBase<ListPermissionQuery, IEnumerable<ListPermissionDto>>(mapper)
    {
        protected override async Task<ResponseDto<IEnumerable<ListPermissionDto>>> HandleQuery(ListPermissionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListPermissionDto>>();

            var user = await userManager.FindByNameAsync(userIdentity.GetCurrentUser());
            if (user == null)
            {
                response.UpdateData(new List<ListPermissionDto>());
                return response;
            }

            var roles = await userManager.GetRolesAsync(user);
            var permissions = await permissionRepository.FindByAsNoTrackingAsync(
                x => x.IsActive && x.Action.IsActive && x.Role.IsActive && roles.Contains(x.Role.Name),
                x => x.Action,
                x => x.Role
            );

            var permissionDtos = _mapper!.Map<IEnumerable<ListPermissionDto>>(permissions);

            response.UpdateData(permissionDtos);

            return response;
        }
    }
}
