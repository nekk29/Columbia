using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Application;
using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Domain.Queries.Application
{
    public class SearchApplicationQuery(SearchParamsDto<SearchApplicationFilterDto> searchParams) : SearchQueryBase<SearchApplicationFilterDto, SearchApplicationDto>(searchParams)
    {

    }
}
