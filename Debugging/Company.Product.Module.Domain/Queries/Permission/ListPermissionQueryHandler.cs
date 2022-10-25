using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Permission;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Security;
using Microsoft.AspNetCore.Identity;

namespace Company.Product.Module.Domain.Queries.Permission
{
    public class ListPermissionQueryHandler : QueryHandlerBase<ListPermissionQuery, IEnumerable<ListPermissionDto>>
    {
        private readonly IUserIdentity _userIdentity;
        private readonly UserManager<Entity.ApplicationUser> _userManager;
        private readonly IRepository<Entity.Permission> _permissionRepository;

        public ListPermissionQueryHandler(
            IMapper mapper,
            IUserIdentity userIdentity,
            UserManager<Entity.ApplicationUser> userManager,
            IRepository<Entity.Permission> permissionRepository
        ) : base(mapper)
        {
            _userIdentity = userIdentity;
            _userManager = userManager;
            _permissionRepository = permissionRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListPermissionDto>>> HandleQuery(ListPermissionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListPermissionDto>>();

            var user = await _userManager.FindByNameAsync(_userIdentity.GetCurrentUser());
            if (user == null)
            {
                response.UpdateData(new List<ListPermissionDto>());
                return response;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var permissions = await _permissionRepository.FindByAsNoTrackingAsync(
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
