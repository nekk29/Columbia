using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Role;
using Company.Product.Module.Repository.Abstractions.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Queries.Role
{
    public class ListRoleQueryHandler : QueryHandlerBase<ListRoleQuery, IEnumerable<ListRoleDto>>
    {
        private readonly IRepository<Entity.AspNetRole> _roleRepository;

        public ListRoleQueryHandler(
            IMapper mapper,
            IRepository<Entity.AspNetRole> roleRepository
        ) : base(mapper)
        {
            _roleRepository = roleRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListRoleDto>>> HandleQuery(ListRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListRoleDto>>();
            var items = await _roleRepository.FindAll().Where(x => x.IsActive).ToListAsync(cancellationToken);
            var itemDtos = _mapper?.Map<IEnumerable<ListRoleDto>>(items);

            response.UpdateData(itemDtos ?? new List<ListRoleDto>());

            return await Task.FromResult(response);
        }
    }
}
