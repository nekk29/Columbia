using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Extensions;

namespace $safesolutionname$.Domain.Queries.Role
{
    public class ListRoleQueryHandler(
        IMapper mapper,
        IRepository<Entity.AspNetRole> roleRepository
    ) : QueryHandlerBase<ListRoleQuery, IEnumerable<ListRoleDto>>(mapper)
    {
        protected override async Task<ResponseDto<IEnumerable<ListRoleDto>>> HandleQuery(ListRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListRoleDto>>();

            Expression<Func<Entity.AspNetRole, bool>> filter = x => x.IsActive;

            if (request.ApplicationId.HasValue)
                filter = filter.And(x => x.ApplicationId == request.ApplicationId.Value);

            var items = await roleRepository
                .FindAll()
                .Where(filter)
                .OrderBy(x => x.Application.Name)
                .ThenBy(x => x.Name)
                .Include(x => x.Application)
                .ToListAsync(cancellationToken);

            var itemDtos = _mapper?.Map<IEnumerable<ListRoleDto>>(items);

            response.UpdateData(itemDtos ?? new List<ListRoleDto>());

            return await Task.FromResult(response);
        }
    }
}
