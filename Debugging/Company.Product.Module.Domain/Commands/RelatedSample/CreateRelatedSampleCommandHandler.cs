using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class CreateRelatedSampleCommandHandler : CommandHandlerBase<CreateRelatedSampleCommand, GetRelatedSampleDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.RelatedSample> _relatedSampleRepository;

        public CreateRelatedSampleCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateRelatedSampleCommandValidator validator,
            IRepository<Entity.RelatedSample> relatedSampleRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _relatedSampleRepository = relatedSampleRepository;
        }

        public override async Task<ResponseDto<GetRelatedSampleDto>> HandleCommand(CreateRelatedSampleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRelatedSampleDto>();
            var relatedSample = _mapper?.Map<Entity.RelatedSample>(request.CreateDto);

            if (relatedSample != null)
            {
                await _relatedSampleRepository.AddAsync(relatedSample);
                await _relatedSampleRepository.SaveAsync();
            }

            var relatedSampleDto = _mapper?.Map<GetRelatedSampleDto>(relatedSample);
            if (relatedSampleDto != null) response.UpdateData(relatedSampleDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
