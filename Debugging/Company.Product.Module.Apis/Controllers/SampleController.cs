using Microsoft.AspNetCore.Mvc;
using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.Apis.Controllers
{
    [ApiController]
    [Route("api/sample")]
    public class SampleController
    {
        private readonly ISampleApplication _sampleApplication;

        public SampleController(ISampleApplication sampleApplication)
            => _sampleApplication = sampleApplication;

        [HttpPost]
        public async Task<ResponseDto<GetSampleDto>> Create(CreateSampleDto createDto)
            => await _sampleApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetSampleDto>> Update(UpdateSampleDto updateDto)
            => await _sampleApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(Guid id)
            => await _sampleApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetSampleDto>> Get(Guid id)
            => await _sampleApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListSampleDto>>> List()
            => await _sampleApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchSampleDto>>> Search(SearchParamsDto<SearchSampleFilterDto> searchParams)
            => await _sampleApplication.Search(searchParams);
    }
}
