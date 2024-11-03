using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.Domain.Queries.Sample
{
    public class GetSampleQuery(Guid id) : QueryBase<GetSampleDto>
    {
        public Guid Id { get; set; } = id;
    }
}
