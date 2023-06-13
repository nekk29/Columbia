using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Domain.Queries.Role
{
    public class SearchRoleQuery : SearchQueryBase<SearchRoleFilterDto, SearchRoleDto>
    {
        public SearchRoleQuery(SearchParamsDto<SearchRoleFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
