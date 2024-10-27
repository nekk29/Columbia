using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Action
{
    public class DeleteActionCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        DeleteActionCommandValidator validator,
        IRepository<Entity.Action> actionRepository
    ) : CommandHandlerBase<DeleteActionCommand>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto> HandleCommand(DeleteActionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var action = await actionRepository.GetByAsync(x => x.Id == request.Id);

            if (action != null)
            {
                await actionRepository.DeleteAsync(action);
                await actionRepository.SaveAsync();
            }

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return response;
        }
    }
}
