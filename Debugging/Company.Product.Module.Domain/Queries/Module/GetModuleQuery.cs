using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Module;

namespace Company.Product.Module.Domain.Queries.Module
{
    public class GetModuleQuery(Guid id) : QueryBase<GetModuleDto>
    {
        public Guid Id { get; set; } = id;
    }
}
