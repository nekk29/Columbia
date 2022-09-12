﻿using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Queries.RelatedSample
{
    public class GetRelatedSampleQueryHandler : QueryHandlerBase<GetRelatedSampleQuery, GetRelatedSampleDto>
    {
        private readonly IRepository<Entity.RelatedSample> _relatedSampleRepository;

        public GetRelatedSampleQueryHandler(
            IMapper mapper,
            IRepository<Entity.RelatedSample> relatedSampleRepository
        ) : base(mapper)
        {
            _relatedSampleRepository = relatedSampleRepository;
        }

        protected override async Task<ResponseDto<GetRelatedSampleDto>> HandleQuery(GetRelatedSampleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRelatedSampleDto>();
            var relatedSample = await _relatedSampleRepository.GetByAsync(x => x.Id == request.Id);
            var relatedSampleDto = _mapper?.Map<GetRelatedSampleDto>(relatedSample);

            if (relatedSampleDto != null)
                response.UpdateData(relatedSampleDto);

            return await Task.FromResult(response);
        }
    }
}