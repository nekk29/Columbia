using Company.Product.Module.Dto.Base;

namespace Company.Product.Module.Domain.Queries.Base
{
    public class SearchQueryBase<TFilter, TResponse> : QueryBase<SearchResultDto<TResponse>>
    {
        public SearchQueryBase(SearchParamsDto<TFilter> searchParams) => SearchParams = searchParams;
        public SearchParamsDto<TFilter> SearchParams { get; set; }
    }
}
