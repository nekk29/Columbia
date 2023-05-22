using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Application.Abstractions
{
    public interface ISettingApplication
    {
        Task<ResponseDto<GetSettingDto>> Update(UpdateSettingDto updateDto);
        Task<ResponseDto<GetSettingDto>> Get(string group, string code);
        Task<ResponseDto<SearchResultDto<SearchSettingDto>>> Search(SearchParamsDto<SearchSettingFilterDto> searchParams);
    }
}
