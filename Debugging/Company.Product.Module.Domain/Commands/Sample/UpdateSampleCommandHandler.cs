using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class UpdateSampleCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        UpdateSampleCommandValidator validator,
        IRepository<Entity.Sample> sampleRepository
    ) : CommandHandlerBase<UpdateSampleCommand, GetSampleDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<GetSampleDto>> HandleCommand(UpdateSampleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetSampleDto>();

            var sample = await sampleRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (sample != null)
            {
                _mapper?.Map(request.UpdateDto, sample);
                await sampleRepository.UpdateAsync(sample);
            }

            var sampleDto = _mapper?.Map<GetSampleDto>(sample);
            if (sampleDto != null) response.UpdateData(sampleDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
