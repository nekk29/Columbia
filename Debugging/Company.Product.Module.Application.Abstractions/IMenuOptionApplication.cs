using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.MenuOption;

namespace Company.Product.Module.Application.Abstractions
{
    public interface IMenuOptionApplication
    {
        Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> List();
        Task<ResponseDto<IEnumerable<TreeMenuOptionDto>>> Tree();
    }
}
