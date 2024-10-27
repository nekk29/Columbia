using MediatR;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.Command.Permission;
using $safesolutionname$.Domain.Queries.Permission;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Permission;

namespace $safesolutionname$.Application
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
