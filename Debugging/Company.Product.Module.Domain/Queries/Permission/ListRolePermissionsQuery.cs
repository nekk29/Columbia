using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Permission;

namespace Company.Product.Module.Domain.Queries.Permission
{
    public class ListRolePermissionsQuery(Guid roleId) : QueryBase<IEnumerable<ListRolePermissionDto>>
    {
        public Guid RoleId { get; set; } = roleId;
    }
}
