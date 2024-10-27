using AutoMapper;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.MenuOption
{
    public class GetMenuOptionQueryHandler(
        IMapper mapper,
        IRepository<Entity.MenuOption> menuOptionRepository
    ) : QueryHandlerBase<GetMenuOptionQuery, GetMenuOptionDto>(mapper)
    {
        protected override async Task<ResponseDto<GetMenuOptionDto>> HandleQuery(GetMenuOptionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetMenuOptionDto>();

            var menuOption = await menuOptionRepository.GetByAsync(
                x => x.Id == request.Id,
                x => x.Application,
                x => x.ParentMenuOption!,
                x => x.Action.Module
            );

            var menuOptionDto = _mapper?.Map<GetMenuOptionDto>(menuOption);

            if (menuOptionDto != null)
                response.UpdateData(menuOptionDto);

            return await Task.FromResult(response);
        }
    }
}
