using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.Domain.Queries.RelatedSample
{
    public class GetRelatedSampleQuery : QueryBase<GetRelatedSampleDto>
    {
        public GetRelatedSampleQuery(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
