using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Action
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
