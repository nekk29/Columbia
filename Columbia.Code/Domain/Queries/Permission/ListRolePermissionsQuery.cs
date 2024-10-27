using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Permission;

namespace $safesolutionname$.Domain.Queries.Permission
{
    public class ListRolePermissionsQuery(Guid roleId) : QueryBase<IEnumerable<ListRolePermissionDto>>
    {
        public Guid RoleId { get; set; } = roleId;
    }
}
