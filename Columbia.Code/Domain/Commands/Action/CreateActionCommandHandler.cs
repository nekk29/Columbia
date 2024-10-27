using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Action;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Action
{
    public class CreateActionCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CreateActionCommandValidator validator,
        IRepository<Entity.Action> actionRepository
    ) : CommandHandlerBase<CreateActionCommand, GetActionDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<GetActionDto>> HandleCommand(CreateActionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetActionDto>();
            var action = _mapper?.Map<Entity.Action>(request.CreateDto);

            if (action != null)
            {
                await actionRepository.AddAsync(action);
                await actionRepository.SaveAsync();
            }

            var actionDto = _mapper?.Map<GetActionDto>(action);
            if (actionDto != null) response.UpdateData(actionDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
