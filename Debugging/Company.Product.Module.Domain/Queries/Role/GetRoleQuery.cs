using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Role;

namespace Company.Product.Module.Domain.Queries.Role
{
    public class GetRoleQuery(Guid id) : QueryBase<GetRoleDto>
    {
        public Guid Id { get; set; } = id;
    }
}
