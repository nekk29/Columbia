using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Action;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Action
{
    public class UpdateActionCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        UpdateActionCommandValidator validator,
        IRepository<Entity.Action> actionRepository
    ) : CommandHandlerBase<UpdateActionCommand, GetActionDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<GetActionDto>> HandleCommand(UpdateActionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetActionDto>();

            var action = await actionRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (action != null)
            {
                _mapper?.Map(request.UpdateDto, action);
                await actionRepository.UpdateAsync(action);
            }

            var actionDto = _mapper?.Map<GetActionDto>(action);
            if (actionDto != null) response.UpdateData(actionDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
