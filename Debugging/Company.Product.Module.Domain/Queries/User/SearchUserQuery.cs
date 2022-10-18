using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Queries.User
{
    public class SearchUserQuery : SearchQueryBase<SearchUserFilterDto, SearchUserDto>
    {
        public SearchUserQuery(SearchParamsDto<SearchUserFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
