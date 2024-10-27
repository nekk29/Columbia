using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.MenuOption;

namespace Company.Product.Module.RestClient.Abstractions
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
