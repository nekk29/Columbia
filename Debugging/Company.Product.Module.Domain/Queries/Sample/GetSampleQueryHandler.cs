using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Queries.Sample
{
    public class GetSampleQueryHandler : QueryHandlerBase<GetSampleQuery, GetSampleDto>
    {
        private readonly IRepository<Entity.Sample> _sampleRepository;

        public GetSampleQueryHandler(
            IMapper mapper,
            IRepository<Entity.Sample> sampleRepository
        ) : base(mapper)
        {
            _sampleRepository = sampleRepository;
        }

        protected override async Task<ResponseDto<GetSampleDto>> HandleQuery(GetSampleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetSampleDto>();
            var sample = await _sampleRepository.GetByAsync(x => x.Id == request.Id);
            var sampleDto = _mapper?.Map<GetSampleDto>(sample);

            if (sampleDto != null)
                response.UpdateData(sampleDto);

            return await Task.FromResult(response);
        }
    }
}
