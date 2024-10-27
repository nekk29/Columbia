using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Queries.User
{
    public class SearchUserQuery(SearchParamsDto<SearchUserFilterDto> searchParams) : SearchQueryBase<SearchUserFilterDto, SearchUserDto>(searchParams)
    {

    }
}
