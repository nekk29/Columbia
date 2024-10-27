using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Permission;

namespace Company.Product.Module.Application.Abstractions
{
    public interface IPermissionApplication
    {
        Task<ResponseDto> AssignPermissions(Guid roleId, IEnumerable<Guid> actionIds);
        Task<ResponseDto<IEnumerable<ListRolePermissionDto>>> ListRole(Guid roleId);
        Task<ResponseDto<IEnumerable<ListPermissionDto>>> ListUser(string applicationCode);
    }
}
