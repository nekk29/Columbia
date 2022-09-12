using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.Domain.Queries.RelatedSample
{
    public class SearchRelatedSampleQuery : SearchQueryBase<SearchRelatedSampleFilterDto, SearchRelatedSampleDto>
    {
        public SearchRelatedSampleQuery(SearchParamsDto<SearchRelatedSampleFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
