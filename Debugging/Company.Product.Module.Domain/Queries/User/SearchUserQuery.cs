using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Queries.User
{
    public class SearchUserQuery(SearchParamsDto<SearchUserFilterDto> searchParams) : SearchQueryBase<SearchUserFilterDto, SearchUserDto>(searchParams)
    {

    }
}
