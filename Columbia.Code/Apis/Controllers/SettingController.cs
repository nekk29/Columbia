using Microsoft.AspNetCore.Mvc;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Apis.Controllers
{
    [ApiController]
    [Route("api/setting")]
    [Security.Authorize]
    public class SettingController
    {
        private readonly ISettingApplication _settingApplication;

        public SettingController(ISettingApplication settingApplication)
            => _settingApplication = settingApplication;

        [HttpPut]
        public async Task<ResponseDto<GetSettingDto>> Update(UpdateSettingDto updateDto)
            => await _settingApplication.Update(updateDto);

        [HttpGet("{group}/{code}")]
        public async Task<ResponseDto<GetSettingDto>> Get(string group, string code)
            => await _settingApplication.Get(group, code);

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchSettingDto>>> Search(SearchParamsDto<SearchSettingFilterDto> searchParams)
            => await _settingApplication.Search(searchParams);
    }
}
