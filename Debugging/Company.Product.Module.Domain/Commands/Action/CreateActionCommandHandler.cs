using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Action;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Action
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
