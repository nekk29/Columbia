using System.Linq.Expressions;
using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Application;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Extensions;

namespace Company.Product.Module.Domain.Queries.Application
{
    public class SearchApplicationQueryHandler(
        IMapper mapper,
        IRepository<Entity.Application> applicationRepository
    ) : SearchQueryHandlerBase<SearchApplicationQuery, SearchApplicationFilterDto, SearchApplicationDto>(mapper)
    {
        protected override async Task<ResponseDto<SearchResultDto<SearchApplicationDto>>> HandleQuery(SearchApplicationQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchApplicationDto>>();

            Expression<Func<Entity.Application, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (!string.IsNullOrEmpty(filters?.Query))
            {
                filter = filter.And(x =>
                    x.Code!.Contains(filters.Query!) ||
                    x.Name!.Contains(filters.Query!)
                );
            }

            var applications = await applicationRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var applicationDtos = _mapper?.Map<IEnumerable<SearchApplicationDto>>(applications.Items);

            var searchResult = new SearchResultDto<SearchApplicationDto>(
                applicationDtos ?? new List<SearchApplicationDto>(),
                applications.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
