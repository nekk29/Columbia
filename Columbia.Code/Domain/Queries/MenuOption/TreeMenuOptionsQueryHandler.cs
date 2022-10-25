using AutoMapper;
using MediatR;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Domain.Queries.Permission;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.MenuOption
{
    public class TreeMenuOptionsQueryHandler : QueryHandlerBase<TreeMenuOptionsQuery, IEnumerable<TreeMenuOptionDto>>
    {
        private readonly IRepository<Entity.MenuOption> _menuOptionRepository;

        public TreeMenuOptionsQueryHandler(
            IMapper mapper,
            IMediator mediator,
            IRepository<Entity.MenuOption> menuOptionRepository
        ) : base(mapper, mediator)
        {
            _menuOptionRepository = menuOptionRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<TreeMenuOptionDto>>> HandleQuery(TreeMenuOptionsQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<TreeMenuOptionDto>>();

            var permissionsResponse = await _mediator!.Send(new ListPermissionQuery());
            var actionIds = permissionsResponse.Data?.Select(x => x.ActionId) ?? new List<Guid>();

            var menuOptions = await _menuOptionRepository.FindByAsNoTrackingAsync(
                x => x.IsActive && actionIds.Contains(x.Action.Id),
                x => x.ParentMenuOption!,
                x => x.Action.Module
            );

            var listMenuOptionDtos = _mapper!.Map<IEnumerable<TreeMenuOptionDto>>(menuOptions);

            listMenuOptionDtos = ToTreeFormat(listMenuOptionDtos, menuOptions);

            response.UpdateData(listMenuOptionDtos);

            return response;
        }

        private IEnumerable<TreeMenuOptionDto> ToTreeFormat(IEnumerable<TreeMenuOptionDto> menuOptionDtos, IEnumerable<Entity.MenuOption> menuOptions)
        {
            var newMenuOptionDtos = new List<TreeMenuOptionDto>();

            var rootMenuOptions = menuOptions.Where(x => !x.ParentMenuOptionId.HasValue);
            var rootMenuOptionCodes = rootMenuOptions.Select(x => x.Code);
            var rootMenuOptionDtos = menuOptionDtos.Where(x => rootMenuOptionCodes.Contains(x.Code));

            newMenuOptionDtos.AddRange(rootMenuOptionDtos.OrderBy(x => x.SortOrder));

            foreach (var newMenuOptionDto in newMenuOptionDtos)
                newMenuOptionDto.Children = ToTreeFormatChildren(newMenuOptionDto, menuOptionDtos, menuOptions);

            return newMenuOptionDtos;
        }

        private IEnumerable<TreeMenuOptionDto> ToTreeFormatChildren(TreeMenuOptionDto menuOptionDto, IEnumerable<TreeMenuOptionDto> menuOptionDtos, IEnumerable<Entity.MenuOption> menuOptions)
        {
            var newChildrenMenuOptionDtos = new List<TreeMenuOptionDto>();

            var childrenMenuOptions = menuOptions.Where(x => x.ParentMenuOption?.Code == menuOptionDto.Code);
            if (!childrenMenuOptions.Any()) return newChildrenMenuOptionDtos;

            var childrenMenuOptionCodes = childrenMenuOptions.Select(x => x.Code);
            var childrenMenuOptionDtos = menuOptionDtos.Where(x => childrenMenuOptionCodes.Contains(x.Code));

            newChildrenMenuOptionDtos.AddRange(childrenMenuOptionDtos.OrderBy(x => x.SortOrder));

            foreach (var newChildrenMenuOptionDto in newChildrenMenuOptionDtos)
                newChildrenMenuOptionDto.Children = ToTreeFormatChildren(newChildrenMenuOptionDto, menuOptionDtos, menuOptions);

            return newChildrenMenuOptionDtos;
        }
    }
}
