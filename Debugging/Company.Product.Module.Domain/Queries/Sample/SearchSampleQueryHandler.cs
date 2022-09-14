using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Extensions;
using System.Linq.Expressions;

namespace Company.Product.Module.Domain.Queries.Sample
{
    public class SearchSampleQueryHandler : SearchQueryHandlerBase<SearchSampleQuery, SearchSampleFilterDto, SearchSampleDto>
    {
        private readonly IRepository<Entity.Sample> _sampleRepository;

        public SearchSampleQueryHandler(
            IMapper mapper,
            IRepository<Entity.Sample> sampleRepository
        ) : base(mapper)
        {
            _sampleRepository = sampleRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchSampleDto>>> HandleQuery(SearchSampleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchSampleDto>>();

            Expression<Func<Entity.Sample, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            /*
                Place your filters here...
            */

            var samples = await _sampleRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
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
