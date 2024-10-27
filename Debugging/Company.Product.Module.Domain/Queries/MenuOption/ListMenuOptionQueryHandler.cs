using System.Linq.Expressions;
using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Domain.Queries.Permission;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.MenuOption;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Queries.MenuOption
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
