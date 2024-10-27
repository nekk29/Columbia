using AutoMapper;
using System.Linq.Expressions;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;
using $safesolutionname$.Entity.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Extensions;

namespace $safesolutionname$.Domain.Queries.Role
{
    public class SearchRoleQueryHandler(
        IMapper mapper,
        IRepository<Entity.AspNetRole> roleRepository
    ) : SearchQueryHandlerBase<SearchRoleQuery, SearchRoleFilterDto, SearchRoleDto>(mapper)
    {
        protected override async Task<ResponseDto<SearchResultDto<SearchRoleDto>>> HandleQuery(SearchRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchRoleDto>>();

            Expression<Func<Entity.AspNetRole, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.ApplicationId.HasValue == true)
                filter = filter.And(x => x.ApplicationId == filters.ApplicationId.Value);

            if (!string.IsNullOrEmpty(filters?.Query))
            {
                filter = filter.And(x =>
                    x.Name!.Contains(filters.Query!) ||
                    x.NormalizedName!.Contains(filters.Query!)
                );
            }

            var sorts = new List<SortExpression<Entity.AspNetRole>>();

            if (request.SearchParams?.Sort?.Any() == true)
            {
                request.SearchParams.Sort.ToList().ForEach(x =>
                {
                    var sort = IQueryableExtensions.GetSortExpression<Entity.AspNetRole>(x.Direction, x.Property);
                    if (sort != null) sorts.Add(sort);
                });
            }
            else
            {
                sorts.Add(new SortExpression<Entity.AspNetRole> { Direction = SortDirection.Asc, Property = x => x.Application.Name });
                sorts.Add(new SortExpression<Entity.AspNetRole> { Direction = SortDirection.Asc, Property = x => x.Name! });
            }

            var roles = await roleRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                sorts,
                filter,
                x => x.Application
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
