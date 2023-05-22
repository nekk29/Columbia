using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Domain.Queries.Setting
{
    public class SearchSettingQuery : SearchQueryBase<SearchSettingFilterDto, SearchSettingDto>
    {
        public SearchSettingQuery(SearchParamsDto<SearchSettingFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
