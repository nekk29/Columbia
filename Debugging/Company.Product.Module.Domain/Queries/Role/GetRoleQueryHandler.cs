using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Role;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Queries.Role
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
            var role = await _roleRepository.GetByAsync(x => x.Id == request.Id);
            var roleDto = _mapper?.Map<GetRoleDto>(role);
            response.UpdateData(roleDto!);
            return await Task.FromResult(response);
        }
    }
}
