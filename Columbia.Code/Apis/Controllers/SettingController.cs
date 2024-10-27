using Microsoft.AspNetCore.Mvc;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Apis.Controllers
{
    [ApiController]
    [Security.Authorize]
    [Route("api/setting")]
    public class SettingController(ISettingApplication settingApplication)
    {
        [HttpPost]
        public async Task<ResponseDto<GetSettingDto>> Create(CreateSettingDto createDto)
            => await settingApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetSettingDto>> Update(UpdateSettingDto updateDto)
            => await settingApplication.Update(updateDto);

        [HttpDelete("{group}/{code}")]
        public async Task<ResponseDto> Delete(string group, string code)
            => await settingApplication.Delete(group, code);

        [HttpGet("{group}/{code}")]
        public async Task<ResponseDto<GetSettingDto>> Get(string group, string code)
            => await settingApplication.Get(group, code);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListSettingDto>>> List()
            => await settingApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchSettingDto>>> Search(SearchParamsDto<SearchSettingFilterDto> searchParams)
            => await settingApplication.Search(searchParams);
    }
}
