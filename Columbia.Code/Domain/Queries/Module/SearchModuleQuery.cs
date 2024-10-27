using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Module;

namespace $safesolutionname$.Domain.Queries.Module
{
    public class SearchModuleQuery(SearchParamsDto<SearchModuleFilterDto> searchParams) : SearchQueryBase<SearchModuleFilterDto, SearchModuleDto>(searchParams)
    {

    }
}
