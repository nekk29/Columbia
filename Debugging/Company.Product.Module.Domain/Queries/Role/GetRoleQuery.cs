using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Role;

namespace Company.Product.Module.Domain.Queries.Role
{
    public class GetRoleQuery : QueryBase<GetRoleDto>
    {
        public GetRoleQuery(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
