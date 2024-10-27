using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Permission;

namespace $safesolutionname$.Application.Abstractions
{
    public interface IPermissionApplication
    {
        Task<ResponseDto> AssignPermissions(Guid roleId, IEnumerable<Guid> actionIds);
        Task<ResponseDto<IEnumerable<ListRolePermissionDto>>> ListRole(Guid roleId);
        Task<ResponseDto<IEnumerable<ListPermissionDto>>> ListUser(string applicationCode);
    }
}
