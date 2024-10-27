using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Queries.User
{
    public class GetUserQuery(Guid id) : QueryBase<GetUserDto>
    {
        public Guid Id { get; set; } = id;
    }
}
