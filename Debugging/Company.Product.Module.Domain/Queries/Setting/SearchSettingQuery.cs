using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;

namespace Company.Product.Module.Domain.Queries.Setting
{
    public class SearchSettingQuery(SearchParamsDto<SearchSettingFilterDto> searchParams) : SearchQueryBase<SearchSettingFilterDto, SearchSettingDto>(searchParams)
    {

    }
}
