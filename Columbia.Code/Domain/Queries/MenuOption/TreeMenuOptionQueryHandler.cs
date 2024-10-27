using AutoMapper;
using MediatR;
using System.Linq.Expressions;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Domain.Queries.Permission;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Extensions;

namespace $safesolutionname$.Domain.Queries.MenuOption
{
    public class TreeMenuOptionQueryHandler(
        IMapper mapper,
        IMediator mediator,
        IRepository<Entity.MenuOption> menuOptionRepository
    ) : QueryHandlerBase<TreeMenuOptionQuery, IEnumerable<TreeMenuOptionDto>>(mapper, mediator)
    {
        protected override async Task<ResponseDto<IEnumerable<TreeMenuOptionDto>>> HandleQuery(TreeMenuOptionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<TreeMenuOptionDto>>();

            Expression<Func<Entity.MenuOption, bool>> filter = x => x.Application.IsActive && x.Application.Code == request.ApplicationCode;

            if (!request.IncludeAll)
            {
                var permissionsResponse = await _mediator!.Send(new ListUserPermissionsQuery(request.ApplicationCode), cancellationToken);
                var actionIds = permissionsResponse.Data?.Select(x => x.ActionId) ?? new List<Guid>();
                filter.And(x => x.IsActive && actionIds.Contains(x.Action.Id));
            }

            var menuOptions = await menuOptionRepository.FindByAsNoTrackingAsync(
                filter,
                x => x.Application,
                x => x.ParentMenuOption!,
                x => x.Action.Module
            );

            var listMenuOptionDtos = _mapper!.Map<IEnumerable<TreeMenuOptionDto>>(menuOptions);

            listMenuOptionDtos = ToTreeFormat(listMenuOptionDtos, menuOptions);

            response.UpdateData(listMenuOptionDtos);

            return response;
        }

        private static List<TreeMenuOptionDto> ToTreeFormat(IEnumerable<TreeMenuOptionDto> menuOptionDtos, IEnumerable<Entity.MenuOption> menuOptions)
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

        private static List<TreeMenuOptionDto> ToTreeFormatChildren(TreeMenuOptionDto menuOptionDto, IEnumerable<TreeMenuOptionDto> menuOptionDtos, IEnumerable<Entity.MenuOption> menuOptions)
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
