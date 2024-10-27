using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;
using Microsoft.AspNetCore.Mvc;

namespace Company.Product.Module.Apis.Controllers
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
