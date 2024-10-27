using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Action;
using Company.Product.Module.Dto.Base;

namespace Company.Product.Module.Domain.Queries.Action
{
    public class SearchActionQuery(SearchParamsDto<SearchActionFilterDto> searchParams) : SearchQueryBase<SearchActionFilterDto, SearchActionDto>(searchParams)
    {

    }
}
