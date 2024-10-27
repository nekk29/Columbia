using System.Linq.Expressions;
using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Action;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Queries.Action
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
