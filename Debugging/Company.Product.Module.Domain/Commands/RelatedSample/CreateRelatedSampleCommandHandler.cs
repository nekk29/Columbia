using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class CreateRelatedSampleCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CreateRelatedSampleCommandValidator validator,
        IRepository<Entity.RelatedSample> relatedSampleRepository
    ) : CommandHandlerBase<CreateRelatedSampleCommand, GetRelatedSampleDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<GetRelatedSampleDto>> HandleCommand(CreateRelatedSampleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRelatedSampleDto>();
            var relatedSample = _mapper?.Map<Entity.RelatedSample>(request.CreateDto);

            if (relatedSample != null)
            {
                await relatedSampleRepository.AddAsync(relatedSample);
                await relatedSampleRepository.SaveAsync();
            }

            var relatedSampleDto = _mapper?.Map<GetRelatedSampleDto>(relatedSample);
            if (relatedSampleDto != null) response.UpdateData(relatedSampleDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
