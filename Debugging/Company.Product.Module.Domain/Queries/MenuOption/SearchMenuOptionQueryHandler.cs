using System.Linq.Expressions;
using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.MenuOption;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Queries.MenuOption
{
    public class SearchMenuOptionQueryHandler(
        IMapper mapper,
        IRepository<Entity.MenuOption> menuOptionRepository
    ) : SearchQueryHandlerBase<SearchMenuOptionQuery, SearchMenuOptionFilterDto, SearchMenuOptionDto>(mapper)
    {
        protected override async Task<ResponseDto<SearchResultDto<SearchMenuOptionDto>>> HandleQuery(SearchMenuOptionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchMenuOptionDto>>();

            Expression<Func<Entity.MenuOption, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            var menuOptions = await menuOptionRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.Application,
                x => x.ParentMenuOption!,
                x => x.Action.Module
            );

            var menuOptionDtos = _mapper?.Map<IEnumerable<SearchMenuOptionDto>>(menuOptions.Items);

            var searchResult = new SearchResultDto<SearchMenuOptionDto>(
                menuOptionDtos ?? new List<SearchMenuOptionDto>(),
                menuOptions.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
