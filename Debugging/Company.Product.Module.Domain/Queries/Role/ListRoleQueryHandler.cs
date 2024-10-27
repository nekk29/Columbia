using System.Linq.Expressions;
using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Role;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Queries.Role
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
