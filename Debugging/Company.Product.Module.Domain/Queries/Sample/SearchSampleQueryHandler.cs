using System.Linq.Expressions;
using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Queries.Sample
{
    public class SearchSampleQueryHandler(
        IMapper mapper,
        IRepository<Entity.Sample> sampleRepository
    ) : SearchQueryHandlerBase<SearchSampleQuery, SearchSampleFilterDto, SearchSampleDto>(mapper)
    {
        protected override async Task<ResponseDto<SearchResultDto<SearchSampleDto>>> HandleQuery(SearchSampleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchSampleDto>>();

            Expression<Func<Entity.Sample, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            /*
                Place your filters here...
            */

            var samples = await sampleRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null, //Include sort expressions...
                filter //Include navigation properties...
            );

            var sampleDtos = _mapper?.Map<IEnumerable<SearchSampleDto>>(samples.Items);

            var searchResult = new SearchResultDto<SearchSampleDto>(
                sampleDtos ?? new List<SearchSampleDto>(),
                samples.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
