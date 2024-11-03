using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.Domain.Queries.RelatedSample
{
    public class SearchRelatedSampleQuery(SearchParamsDto<SearchRelatedSampleFilterDto> searchParams) : SearchQueryBase<SearchRelatedSampleFilterDto, SearchRelatedSampleDto>(searchParams)
    {

    }
}
