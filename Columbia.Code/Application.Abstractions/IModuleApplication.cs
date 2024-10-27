using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Module;

namespace $safesolutionname$.Application.Abstractions
{
    public interface IModuleApplication
    {
        Task<ResponseDto<GetModuleDto>> Create(CreateModuleDto createDto);
        Task<ResponseDto<GetModuleDto>> Update(UpdateModuleDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetModuleDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListModuleDto>>> List();
        Task<ResponseDto<IEnumerable<ListModuleDto>>> List(Guid applicationId);
        Task<ResponseDto<IEnumerable<ListModuleDto>>> ListSimple(Guid applicationId);
        Task<ResponseDto<SearchResultDto<SearchModuleDto>>> Search(SearchParamsDto<SearchModuleFilterDto> searchParams);
    }
}
