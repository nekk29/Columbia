using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Permission;

namespace $safesolutionname$.Application.Abstractions
{
    public interface IPermissionApplication
    {
        Task<ResponseDto<IEnumerable<ListPermissionDto>>> List();
    }
}
