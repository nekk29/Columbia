using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Application;
using Company.Product.Module.Dto.Base;

namespace Company.Product.Module.Domain.Queries.Application
{
    public class SearchApplicationQuery(SearchParamsDto<SearchApplicationFilterDto> searchParams) : SearchQueryBase<SearchApplicationFilterDto, SearchApplicationDto>(searchParams)
    {

    }
}
