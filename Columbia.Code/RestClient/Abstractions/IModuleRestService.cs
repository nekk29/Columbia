using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Module;

namespace $safesolutionname$.RestClient.Abstractions
{
    public interface IModuleRestService
    {
        Task<ResponseDto<GetModuleDto>> Create(CreateModuleDto createDto);
        Task<ResponseDto<GetModuleDto>> Update(UpdateModuleDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetModuleDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListModuleDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchModuleDto>>> Search(SearchParamsDto<SearchModuleFilterDto> filter);
    }
}
