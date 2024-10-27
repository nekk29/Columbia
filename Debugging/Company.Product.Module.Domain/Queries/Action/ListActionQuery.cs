using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Action;

namespace Company.Product.Module.Domain.Queries.Action
{
    public class ListActionQuery(Guid? moduleId = null) : QueryBase<IEnumerable<ListActionDto>>
    {
        public Guid? ModuleId { get; set; } = moduleId;
    }
}
