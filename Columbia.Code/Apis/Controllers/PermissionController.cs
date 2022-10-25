using Microsoft.AspNetCore.Mvc;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Permission;

namespace $safesolutionname$.Apis.Controllers
{
    [ApiController]
    [Route("api/permission")]
    [Security.Authorize]
    public class PermissionController
    {
        private readonly IPermissionApplication _permissionApplication;

        public PermissionController(IPermissionApplication permissionApplication)
            => _permissionApplication = permissionApplication;

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListPermissionDto>>> List()
            => await _permissionApplication.List();
    }
}
