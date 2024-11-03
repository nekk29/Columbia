using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class CreateSampleCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CreateSampleCommandValidator validator,
        IRepository<Entity.Sample> sampleRepository
    ) : CommandHandlerBase<CreateSampleCommand, GetSampleDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<GetSampleDto>> HandleCommand(CreateSampleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetSampleDto>();
            var sample = _mapper?.Map<Entity.Sample>(request.CreateDto);

            if (sample != null)
            {
                await sampleRepository.AddAsync(sample);
                await sampleRepository.SaveAsync();
            }

            var sampleDto = _mapper?.Map<GetSampleDto>(sample);
            if (sampleDto != null) response.UpdateData(sampleDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
