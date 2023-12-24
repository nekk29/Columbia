using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;
using $safesolutionname$.Entity;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Role
{
    public class UpdateRoleCommandHandler : CommandHandlerBase<UpdateRoleCommand, GetRoleDto>
    {
        private readonly IRepository<AspNetRole> _roleRepository;

        public UpdateRoleCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateRoleCommandValidator validator,
            IRepository<AspNetRole> roleRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _roleRepository = roleRepository;
        }

        public override async Task<ResponseDto<GetRoleDto>> HandleCommand(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRoleDto>();

            var role = await _roleRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (role != null)
            {
                _mapper?.Map(request.UpdateDto, role);
                role.NormalizedName = role.Name?.ToUpper();
                await _roleRepository.UpdateAsync(role);
            }

            var roleDto = _mapper?.Map<GetRoleDto>(role);
            if (roleDto != null) response.UpdateData(roleDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
