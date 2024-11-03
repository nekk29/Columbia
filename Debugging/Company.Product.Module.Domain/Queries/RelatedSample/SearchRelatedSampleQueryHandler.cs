using System.Linq.Expressions;
using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Queries.RelatedSample
{
    public class SearchRelatedSampleQueryHandler(
        IMapper mapper,
        IRepository<Entity.RelatedSample> relatedSampleRepository
    ) : SearchQueryHandlerBase<SearchRelatedSampleQuery, SearchRelatedSampleFilterDto, SearchRelatedSampleDto>(mapper)
    {
        protected override async Task<ResponseDto<SearchResultDto<SearchRelatedSampleDto>>> HandleQuery(SearchRelatedSampleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchRelatedSampleDto>>();

            Expression<Func<Entity.RelatedSample, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            /*
                Place your filters here...
            */

            var relatedSamples = await relatedSampleRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null, //Include sort expressions...
                filter //Include navigation properties...
            );

            var relatedSampleDtos = _mapper?.Map<IEnumerable<SearchRelatedSampleDto>>(relatedSamples.Items);

            var searchResult = new SearchResultDto<SearchRelatedSampleDto>(
                relatedSampleDtos ?? new List<SearchRelatedSampleDto>(),
                relatedSamples.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
