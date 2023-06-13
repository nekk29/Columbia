using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Role;

namespace Company.Product.Module.Domain.Queries.Role
{
    public class SearchRoleQuery : SearchQueryBase<SearchRoleFilterDto, SearchRoleDto>
    {
        public SearchRoleQuery(SearchParamsDto<SearchRoleFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
