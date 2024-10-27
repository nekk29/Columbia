using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.RestClient.Abstractions
{
    public interface ISettingRestService
    {
        Task<ResponseDto<GetSettingDto>> Create(CreateSettingDto createDto);
        Task<ResponseDto<GetSettingDto>> Update(UpdateSettingDto updateDto);
        Task<ResponseDto> Delete();
        Task<ResponseDto<GetSettingDto>> Get();
        Task<ResponseDto<IEnumerable<ListSettingDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchSettingDto>>> Search(SearchParamsDto<SearchSettingFilterDto> filter);
    }
}
