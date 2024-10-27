using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Domain.Queries.Setting
{
    public class SearchSettingQuery(SearchParamsDto<SearchSettingFilterDto> searchParams) : SearchQueryBase<SearchSettingFilterDto, SearchSettingDto>(searchParams)
    {

    }
}
