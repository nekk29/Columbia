using Microsoft.AspNetCore.Mvc;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Permission;

namespace $safesolutionname$.Apis.Controllers
{
    [ApiController]
    [Security.Authorize]
    [Route("api/permission")]
    public class PermissionController(IPermissionApplication permissionApplication)
    {
        [HttpPost]
        [Route("{roleId}/assign")]
        public async Task<ResponseDto> AssignRolePermissions(Guid roleId, [FromBody] IEnumerable<Guid> actionIds)
            => await permissionApplication.AssignPermissions(roleId, actionIds);

        [HttpGet("{roleId}/role-permissions")]
        public async Task<ResponseDto<IEnumerable<ListRolePermissionDto>>> ListRole(Guid roleId)
            => await permissionApplication.ListRole(roleId);

        [HttpGet("{applicationCode}/user-permissions")]
        public async Task<ResponseDto<IEnumerable<ListPermissionDto>>> ListUser(string applicationCode)
            => await permissionApplication.ListUser(applicationCode);
    }
}
