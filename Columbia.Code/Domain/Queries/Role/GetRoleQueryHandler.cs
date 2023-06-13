using AutoMapper;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.Role
{
    public class GetRoleQueryHandler : QueryHandlerBase<GetRoleQuery, GetRoleDto>
    {
        private readonly IRepository<Entity.AspNetRole> _roleRepository;

        public GetRoleQueryHandler(
            IMapper mapper,
            IRepository<Entity.AspNetRole> roleRepository
        ) : base(mapper)
        {
            _roleRepository = roleRepository;
        }

        protected override async Task<ResponseDto<GetRoleDto>> HandleQuery(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRoleDto>();
            var role = await _roleRepository.GetByAsync(x => x.Id == request.Id && x.IsActive);
            var roleDto = _mapper?.Map<GetRoleDto>(role);
            response.UpdateData(roleDto!);
            return await Task.FromResult(response);
        }
    }
}
