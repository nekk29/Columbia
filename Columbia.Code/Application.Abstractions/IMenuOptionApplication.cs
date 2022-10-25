using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.Application.Abstractions
{
    public interface IMenuOptionApplication
    {
        Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> List();
        Task<ResponseDto<IEnumerable<TreeMenuOptionDto>>> Tree();
    }
}
