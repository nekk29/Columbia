using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Role;

namespace Company.Product.Module.Domain.Queries.Role
{
    public class ListRoleQuery(Guid? applicationId = null) : QueryBase<IEnumerable<ListRoleDto>>
    {
        public Guid? ApplicationId { get; set; } = applicationId;
    }
}
