using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Domain.Queries.Permission;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Extensions;

namespace $safesolutionname$.Domain.Queries.MenuOption
{
    public class ListMenuOptionQueryHandler(
        IMapper mapper,
        IMediator mediator,
        IRepository<Entity.MenuOption> menuOptionRepository
    ) : QueryHandlerBase<ListMenuOptionQuery, IEnumerable<ListMenuOptionDto>>(mapper, mediator)
    {
        protected override async Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> HandleQuery(ListMenuOptionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListMenuOptionDto>>();

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

            var listMenuOptionDtos = _mapper!.Map<IEnumerable<ListMenuOptionDto>>(menuOptions);

            listMenuOptionDtos = listMenuOptionDtos.OrderBy(x => x.SortOrder);

            response.UpdateData(listMenuOptionDtos);

            return response;
        }
    }
}
