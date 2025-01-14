﻿using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class UpdateRelatedSampleCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        UpdateRelatedSampleCommandValidator validator,
        IRepository<Entity.RelatedSample> relatedSampleRepository
    ) : CommandHandlerBase<UpdateRelatedSampleCommand, GetRelatedSampleDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<GetRelatedSampleDto>> HandleCommand(UpdateRelatedSampleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRelatedSampleDto>();

            var relatedSample = await relatedSampleRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (relatedSample != null)
            {
                _mapper?.Map(request.UpdateDto, relatedSample);
                await relatedSampleRepository.UpdateAsync(relatedSample);
            }

            var relatedSampleDto = _mapper?.Map<GetRelatedSampleDto>(relatedSample);
            if (relatedSampleDto != null) response.UpdateData(relatedSampleDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
