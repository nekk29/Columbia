using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class DeleteSampleCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        DeleteSampleCommandValidator validator,
        IRepository<Entity.Sample> sampleRepository
    ) : CommandHandlerBase<DeleteSampleCommand>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto> HandleCommand(DeleteSampleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var sample = await sampleRepository.GetByAsync(x => x.Id == request.Id);

            if (sample != null)
            {
                await sampleRepository.DeleteAsync(sample);
            }

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return response;
        }
    }
}
