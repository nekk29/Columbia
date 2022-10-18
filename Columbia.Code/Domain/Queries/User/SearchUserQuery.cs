using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Queries.User
{
    public class SearchUserQuery : SearchQueryBase<SearchUserFilterDto, SearchUserDto>
    {
        public SearchUserQuery(SearchParamsDto<SearchUserFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
