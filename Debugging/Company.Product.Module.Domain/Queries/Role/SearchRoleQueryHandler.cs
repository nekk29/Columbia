using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Role;
using Company.Product.Module.Repository.Abstractions.Base;
using System.Linq.Expressions;

namespace Company.Product.Module.Domain.Queries.Role
{
    public class SearchRoleQueryHandler : SearchQueryHandlerBase<SearchRoleQuery, SearchRoleFilterDto, SearchRoleDto>
    {
        private readonly IRepository<Entity.AspNetRole> _roleRepository;

        public SearchRoleQueryHandler(
            IMapper mapper,
            IRepository<Entity.AspNetRole> roleRepository
        ) : base(mapper)
        {
            _roleRepository = roleRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchRoleDto>>> HandleQuery(SearchRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchRoleDto>>();

            Expression<Func<Entity.AspNetRole, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            /*
                Place your filters here...
            */

            var roles = await _roleRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null, //Include sort expressions...
                filter //Include navigation properties...
            );

            var roleDtos = _mapper?.Map<IEnumerable<SearchRoleDto>>(roles.Items);

            /*if (users.Items != null && users.Items.Count() > 0)
            {
                foreach (var user in users.Items)
                {
                    var role = user.Roles.FirstOrDefault();
                    var 
            }*/

            var searchResult = new SearchResultDto<SearchRoleDto>(
                roleDtos ?? new List<SearchRoleDto>(),
                roles.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
