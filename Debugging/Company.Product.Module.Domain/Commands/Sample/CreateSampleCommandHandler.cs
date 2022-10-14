using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class CreateSampleCommandHandler : CommandHandlerBase<CreateSampleCommand, GetSampleDto>
    {
        private readonly IRepository<Entity.Sample> _sampleRepository;

        public CreateSampleCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateSampleCommandValidator validator,
            IRepository<Entity.Sample> sampleRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _sampleRepository = sampleRepository;
        }

        public override async Task<ResponseDto<GetSampleDto>> HandleCommand(CreateSampleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetSampleDto>();
            var sample = _mapper?.Map<Entity.Sample>(request.CreateDto);

            if (sample != null)
            {
                await _sampleRepository.AddAsync(sample);
                await _sampleRepository.SaveAsync();
            }

            var sampleDto = _mapper?.Map<GetSampleDto>(sample);
            if (sampleDto != null) response.UpdateData(sampleDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
