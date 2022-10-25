using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Permission;
using Microsoft.AspNetCore.Mvc;

namespace Company.Product.Module.Apis.Controllers
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
