using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Role;
using Company.Product.Module.Entity;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Role
{
    public class UpdateRoleCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        UpdateRoleCommandValidator validator,
        IRepository<AspNetRole> roleRepository
    ) : CommandHandlerBase<UpdateRoleCommand, GetRoleDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<GetRoleDto>> HandleCommand(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRoleDto>();

            var role = await roleRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (role != null)
            {
                _mapper?.Map(request.UpdateDto, role);
                role.NormalizedName = role.Name?.ToUpper();
                await roleRepository.UpdateAsync(role);
            }

            var roleDto = _mapper?.Map<GetRoleDto>(role);
            if (roleDto != null) response.UpdateData(roleDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
