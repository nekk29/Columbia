using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Application.Base;
using Company.Product.Module.Domain.Command.Permission;
using Company.Product.Module.Domain.Queries.Permission;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Permission;
using MediatR;

namespace Company.Product.Module.Application
{
    public class PermissionApplication(IMediator mediator) : ApplicationBase(mediator), IPermissionApplication
    {
        public async Task<ResponseDto> AssignPermissions(Guid roleId, IEnumerable<Guid> actionIds)
            => await _mediator.Send(new AssignPermissionsCommand(roleId, actionIds));

        public async Task<ResponseDto<IEnumerable<ListRolePermissionDto>>> ListRole(Guid roleId)
            => await _mediator.Send(new ListRolePermissionsQuery(roleId));

        public async Task<ResponseDto<IEnumerable<ListPermissionDto>>> ListUser(string applicationCode)
            => await _mediator.Send(new ListUserPermissionsQuery(applicationCode));
    }
}
