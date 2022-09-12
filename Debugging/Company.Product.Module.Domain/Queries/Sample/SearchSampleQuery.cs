using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.Domain.Queries.Sample
{
    public class SearchSampleQuery : SearchQueryBase<SearchSampleFilterDto, SearchSampleDto>
    {
        public SearchSampleQuery(SearchParamsDto<SearchSampleFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
