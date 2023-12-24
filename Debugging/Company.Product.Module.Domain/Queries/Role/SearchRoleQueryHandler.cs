using System.Linq.Expressions;
using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Role;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Extensions;

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

            if (!string.IsNullOrEmpty(filters?.Query))
            {
                filter = filter.And(x =>
                    x.Name!.Contains(filters.Query!) ||
                    x.NormalizedName!.Contains(filters.Query!)
                );
            }

            var roles = await _roleRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var roleDtos = _mapper?.Map<IEnumerable<SearchRoleDto>>(roles.Items);

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
