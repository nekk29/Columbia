using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Module;

namespace Company.Product.Module.Domain.Queries.Module
{
    public class SearchModuleQuery(SearchParamsDto<SearchModuleFilterDto> searchParams) : SearchQueryBase<SearchModuleFilterDto, SearchModuleDto>(searchParams)
    {

    }
}
