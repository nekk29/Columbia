using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Queries.User
{
    public class GetUserQuery : QueryBase<GetUserDto>
    {
        public GetUserQuery(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
