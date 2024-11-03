using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.Domain.Queries.Sample
{
    public class SearchSampleQuery(SearchParamsDto<SearchSampleFilterDto> searchParams) : SearchQueryBase<SearchSampleFilterDto, SearchSampleDto>(searchParams)
    {

    }
}
