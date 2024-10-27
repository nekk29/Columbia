using AutoMapper;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Action;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.Action
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
