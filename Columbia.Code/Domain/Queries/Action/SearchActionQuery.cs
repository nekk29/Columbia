using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Action;
using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Domain.Queries.Action
{
    public class SearchActionQuery(SearchParamsDto<SearchActionFilterDto> searchParams) : SearchQueryBase<SearchActionFilterDto, SearchActionDto>(searchParams)
    {

    }
}
