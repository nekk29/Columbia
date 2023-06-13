using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Domain.Queries.Role
{
    public class GetRoleQuery : QueryBase<GetRoleDto>
    {
        public GetRoleQuery(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
