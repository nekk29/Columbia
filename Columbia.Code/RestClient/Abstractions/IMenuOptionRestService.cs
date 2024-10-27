using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.RestClient.Abstractions
{
    public interface IMenuOptionRestService
    {
        Task<ResponseDto<GetMenuOptionDto>> Create(CreateMenuOptionDto createDto);
        Task<ResponseDto<GetMenuOptionDto>> Update(UpdateMenuOptionDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetMenuOptionDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchMenuOptionDto>>> Search(SearchParamsDto<SearchMenuOptionFilterDto> filter);
    }
}
