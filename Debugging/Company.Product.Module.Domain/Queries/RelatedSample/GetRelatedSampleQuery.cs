using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.Domain.Queries.RelatedSample
{
    public class GetRelatedSampleQuery(Guid id) : QueryBase<GetRelatedSampleDto>
    {
        public Guid Id { get; set; } = id;
    }
}
