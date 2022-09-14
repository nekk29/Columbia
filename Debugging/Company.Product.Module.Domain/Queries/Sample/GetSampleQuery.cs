using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.Domain.Queries.Sample
{
    public class GetSampleQuery : QueryBase<GetSampleDto>
    {
        public GetSampleQuery(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
