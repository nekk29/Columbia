using AutoMapper;
using MediatR;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Domain.Queries.Permission;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.MenuOption
{
    public class ListMenuOptionsQueryHandler : QueryHandlerBase<ListMenuOptionsQuery, IEnumerable<ListMenuOptionDto>>
    {
        private readonly IRepository<Entity.MenuOption> _menuOptionRepository;

        public ListMenuOptionsQueryHandler(
            IMapper mapper,
            IMediator mediator,
            IRepository<Entity.MenuOption> menuOptionRepository
        ) : base(mapper, mediator)
        {
            _menuOptionRepository = menuOptionRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> HandleQuery(ListMenuOptionsQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListMenuOptionDto>>();

            var permissionsResponse = await _mediator!.Send(new ListPermissionQuery());
            var actionIds = permissionsResponse.Data?.Select(x => x.ActionId) ?? new List<Guid>();

            var menuOptions = await _menuOptionRepository.FindByAsNoTrackingAsync(
                x => x.IsActive && actionIds.Contains(x.Action.Id),
                x => x.ParentMenuOption!,
                x => x.Action.Module
            );

            var listMenuOptionDtos = _mapper!.Map<IEnumerable<ListMenuOptionDto>>(menuOptions);

            listMenuOptionDtos = listMenuOptionDtos.OrderBy(x => x.SortOrder);

            response.UpdateData(listMenuOptionDtos);

            return response;
        }
    }
}
