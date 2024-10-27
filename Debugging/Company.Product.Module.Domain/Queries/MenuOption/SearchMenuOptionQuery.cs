using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.MenuOption;

namespace Company.Product.Module.Domain.Queries.MenuOption
{
    public class SearchMenuOptionQuery(SearchParamsDto<SearchMenuOptionFilterDto> searchParams) : SearchQueryBase<SearchMenuOptionFilterDto, SearchMenuOptionDto>(searchParams)
    {

    }
}
