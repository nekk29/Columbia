using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;
using Company.Product.Module.Repository.Abstractions.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Queries.Sample
{
    public class ListSampleQueryHandler : QueryHandlerBase<ListSampleQuery, IEnumerable<ListSampleDto>>
    {
        private readonly IRepository<Entity.Sample> _sampleRepository;

        public ListSampleQueryHandler(
            IMapper mapper,
            IRepository<Entity.Sample> sampleRepository
        ) : base(mapper)
        {
            _sampleRepository = sampleRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListSampleDto>>> HandleQuery(ListSampleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListSampleDto>>();
            var items = await _sampleRepository.FindAll().ToListAsync(cancellationToken);
            var itemDtos = _mapper?.Map<IEnumerable<ListSampleDto>>(items);

            response.UpdateData(itemDtos ?? new List<ListSampleDto>());

            return await Task.FromResult(response);
        }
    }
}
