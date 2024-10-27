using AutoMapper;
using System.Linq.Expressions;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Action;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.Action
{
    public class SearchActionQueryHandler(
        IMapper mapper,
        IRepository<Entity.Action> actionRepository
        ) : SearchQueryHandlerBase<SearchActionQuery, SearchActionFilterDto, SearchActionDto>(mapper)
    {
        protected override async Task<ResponseDto<SearchResultDto<SearchActionDto>>> HandleQuery(SearchActionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchActionDto>>();

            Expression<Func<Entity.Action, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            var actions = await actionRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var actionDtos = _mapper?.Map<IEnumerable<SearchActionDto>>(actions.Items);

            var searchResult = new SearchResultDto<SearchActionDto>(
                actionDtos ?? new List<SearchActionDto>(),
                actions.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
