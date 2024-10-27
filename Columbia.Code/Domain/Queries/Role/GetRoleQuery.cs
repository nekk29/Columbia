using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Domain.Queries.Role
{
    public class GetRoleQuery(Guid id) : QueryBase<GetRoleDto>
    {
        public Guid Id { get; set; } = id;
    }
}
