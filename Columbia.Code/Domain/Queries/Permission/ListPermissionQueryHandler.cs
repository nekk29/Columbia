using AutoMapper;
using Microsoft.AspNetCore.Identity;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Permission;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Security;

namespace $safesolutionname$.Domain.Queries.Permission
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
