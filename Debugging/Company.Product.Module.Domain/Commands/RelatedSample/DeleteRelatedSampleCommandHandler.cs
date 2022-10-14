using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class DeleteRelatedSampleCommandHandler : CommandHandlerBase<DeleteRelatedSampleCommand>
    {
        private readonly IRepository<Entity.RelatedSample> _relatedSampleRepository;

        public DeleteRelatedSampleCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteRelatedSampleCommandValidator validator,
            IRepository<Entity.RelatedSample> relatedSampleRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _relatedSampleRepository = relatedSampleRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteRelatedSampleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var relatedSample = await _relatedSampleRepository.GetByAsync(x => x.Id == request.Id);

            if (relatedSample != null)
            {
                relatedSample.IsActive = false;
                await _relatedSampleRepository.UpdateAsync(relatedSample);
            }

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return response;
        }
    }
}
