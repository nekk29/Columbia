using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;
using Microsoft.AspNetCore.Mvc;

namespace Company.Product.Module.Apis.Controllers
{
    [ApiController]
    [Security.Authorize]
    [Route("api/sample")]
    public class SampleController(ISampleApplication sampleApplication)
    {
        [HttpPost]
        public async Task<ResponseDto<GetSampleDto>> Create(CreateSampleDto createDto)
            => await sampleApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetSampleDto>> Update(UpdateSampleDto updateDto)
            => await sampleApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(Guid id)
            => await sampleApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetSampleDto>> Get(Guid id)
            => await sampleApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListSampleDto>>> List()
            => await sampleApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchSampleDto>>> Search(SearchParamsDto<SearchSampleFilterDto> searchParams)
            => await sampleApplication.Search(searchParams);
    }
}
