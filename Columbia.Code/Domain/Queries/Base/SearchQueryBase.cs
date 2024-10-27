using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Domain.Queries.Base
{
    public class SearchQueryBase<TFilter, TResponse>(SearchParamsDto<TFilter> searchParams) : QueryBase<SearchResultDto<TResponse>>
    {
        public SearchParamsDto<TFilter> SearchParams { get; set; } = searchParams;
    }
}
