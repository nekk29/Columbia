using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.Application.Abstractions
{
    public interface IMenuOptionApplication
    {
        Task<ResponseDto<GetMenuOptionDto>> Create(CreateMenuOptionDto createDto);
        Task<ResponseDto<GetMenuOptionDto>> Update(UpdateMenuOptionDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetMenuOptionDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> List(string applicationCode);
        Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> ListAll(string applicationCode);
        Task<ResponseDto<IEnumerable<TreeMenuOptionDto>>> Tree(string applicationCode);
        Task<ResponseDto<IEnumerable<TreeMenuOptionDto>>> TreeAll(string applicationCode);
        Task<ResponseDto<SearchResultDto<SearchMenuOptionDto>>> Search(SearchParamsDto<SearchMenuOptionFilterDto> searchParams);
    }
}
