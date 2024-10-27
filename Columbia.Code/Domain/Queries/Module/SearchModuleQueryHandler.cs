﻿using AutoMapper;
using System.Linq.Expressions;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Module;
using $safesolutionname$.Entity.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Extensions;

namespace $safesolutionname$.Domain.Queries.Module
{
    public class SearchModuleQueryHandler(
        IMapper mapper,
        IRepository<Entity.Module> moduleRepository
    ) : SearchQueryHandlerBase<SearchModuleQuery, SearchModuleFilterDto, SearchModuleDto>(mapper)
    {
        protected override async Task<ResponseDto<SearchResultDto<SearchModuleDto>>> HandleQuery(SearchModuleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchModuleDto>>();

            Expression<Func<Entity.Module, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.ApplicationId.HasValue == true)
                filter = filter.And(x => x.ApplicationId == filters.ApplicationId.Value);

            if (!string.IsNullOrEmpty(filters?.Query))
            {
                filter = filter.And(x =>
                    x.Name!.Contains(filters.Query!) ||
                    x.Description!.Contains(filters.Query!)
                );
            }

            var sorts = new List<SortExpression<Entity.Module>>();

            if (request.SearchParams?.Sort?.Any() == true)
            {
                request.SearchParams.Sort.ToList().ForEach(x =>
                {
                    var sort = IQueryableExtensions.GetSortExpression<Entity.Module>(x.Direction, x.Property);
                    if (sort != null) sorts.Add(sort);
                });
            }
            else
            {
                sorts.Add(new SortExpression<Entity.Module> { Direction = SortDirection.Asc, Property = x => x.Application.Name });
                sorts.Add(new SortExpression<Entity.Module> { Direction = SortDirection.Asc, Property = x => x.Name! });
            }

            var modules = await moduleRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                sorts,
                filter,
                x => x.Application
            );

            var moduleDtos = _mapper?.Map<IEnumerable<SearchModuleDto>>(modules.Items);

            var searchResult = new SearchResultDto<SearchModuleDto>(
                moduleDtos ?? new List<SearchModuleDto>(),
                modules.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
