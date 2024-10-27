using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.Domain.Queries.MenuOption
{
    public class SearchMenuOptionQuery(SearchParamsDto<SearchMenuOptionFilterDto> searchParams) : SearchQueryBase<SearchMenuOptionFilterDto, SearchMenuOptionDto>(searchParams)
    {

    }
}
