using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Permission;

namespace Company.Product.Module.Domain.Queries.Permission
{
    public class ListUserPermissionsQuery(string applicationCode) : QueryBase<IEnumerable<ListPermissionDto>>
    {
        public string ApplicationCode { get; set; } = applicationCode;
    }
}
