using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Domain.Queries.Role
{
    public class ListRoleQuery(Guid? applicationId = null) : QueryBase<IEnumerable<ListRoleDto>>
    {
        public Guid? ApplicationId { get; set; } = applicationId;
    }
}
