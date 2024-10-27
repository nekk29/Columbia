using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class UpdateSampleCommandHandler : CommandHandlerBase<UpdateSampleCommand, GetSampleDto>
    {
        private readonly IRepository<Entity.Sample> _sampleRepository;

        public UpdateSampleCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateSampleCommandValidator validator,
            IRepository<Entity.Sample> sampleRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _sampleRepository = sampleRepository;
        }

        public override async Task<ResponseDto<GetSampleDto>> HandleCommand(UpdateSampleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetSampleDto>();

            var sample = await _sampleRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (sample != null)
            {
                _mapper?.Map(request.UpdateDto, sample);
                await _sampleRepository.UpdateAsync(sample);
            }

            var sampleDto = _mapper?.Map<GetSampleDto>(sample);
            if (sampleDto != null) response.UpdateData(sampleDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
