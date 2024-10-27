using $safesolutionname$.Dto.Action;
using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Application.Abstractions
{
    public interface IActionApplication
    {
        Task<ResponseDto<GetActionDto>> Create(CreateActionDto createDto);
        Task<ResponseDto<GetActionDto>> Update(UpdateActionDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetActionDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListActionDto>>> List();
        Task<ResponseDto<IEnumerable<ListActionDto>>> List(Guid moduleId);
        Task<ResponseDto<SearchResultDto<SearchActionDto>>> Search(SearchParamsDto<SearchActionFilterDto> searchParams);
    }
}
