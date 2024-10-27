using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Permission;

namespace $safesolutionname$.Domain.Queries.Permission
{
    public class ListUserPermissionsQuery(string applicationCode) : QueryBase<IEnumerable<ListPermissionDto>>
    {
        public string ApplicationCode { get; set; } = applicationCode;
    }
}
