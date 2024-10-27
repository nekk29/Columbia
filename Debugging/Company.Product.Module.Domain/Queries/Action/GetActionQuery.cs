using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Action;

namespace Company.Product.Module.Domain.Queries.Action
{
    public class GetActionQuery(Guid id) : QueryBase<GetActionDto>
    {
        public Guid Id { get; set; } = id;
    }
}
