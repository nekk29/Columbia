using Microsoft.AspNetCore.Mvc;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Dto.Application;
using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Apis.Controllers
{
    [ApiController]
    [Security.Authorize]
    [Route("api/application")]
    public class ApplicationController(IApplicationApplication applicationApplication)
    {
        [HttpPost]
        public async Task<ResponseDto<GetApplicationDto>> Create(CreateApplicationDto createDto)
            => await applicationApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetApplicationDto>> Update(UpdateApplicationDto updateDto)
            => await applicationApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(Guid id)
            => await applicationApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetApplicationDto>> Get(Guid id)
            => await applicationApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListApplicationDto>>> List()
            => await applicationApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchApplicationDto>>> Search(SearchParamsDto<SearchApplicationFilterDto> searchParams)
            => await applicationApplication.Search(searchParams);
    }
}
