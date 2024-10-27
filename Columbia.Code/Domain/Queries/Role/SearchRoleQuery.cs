using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Domain.Queries.Role
{
    public class SearchRoleQuery(SearchParamsDto<SearchRoleFilterDto> searchParams) : SearchQueryBase<SearchRoleFilterDto, SearchRoleDto>(searchParams)
    {

    }
}
