using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Permission;

namespace Company.Product.Module.Application.Abstractions
{
    public interface IPermissionApplication
    {
        Task<ResponseDto<IEnumerable<ListPermissionDto>>> List();
    }
}
