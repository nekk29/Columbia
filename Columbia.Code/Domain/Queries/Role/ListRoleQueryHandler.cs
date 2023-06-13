using AutoMapper;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.Role
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
