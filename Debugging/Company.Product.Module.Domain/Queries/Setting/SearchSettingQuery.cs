using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;

namespace Company.Product.Module.Domain.Queries.Setting
{
    public class SearchSettingQuery : SearchQueryBase<SearchSettingFilterDto, SearchSettingDto>
    {
        public SearchSettingQuery(SearchParamsDto<SearchSettingFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
