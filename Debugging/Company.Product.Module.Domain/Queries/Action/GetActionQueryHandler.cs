using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Action;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Queries.Action
{
    public class GetActionQueryHandler(
        IMapper mapper,
        IRepository<Entity.Action> actionRepository
    ) : QueryHandlerBase<GetActionQuery, GetActionDto>(mapper)
    {
        protected override async Task<ResponseDto<GetActionDto>> HandleQuery(GetActionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetActionDto>();
            var action = await actionRepository.GetByAsync(x => x.Id == request.Id);
            var actionDto = _mapper?.Map<GetActionDto>(action);

            if (actionDto != null)
                response.UpdateData(actionDto);

            return await Task.FromResult(response);
        }
    }
}
