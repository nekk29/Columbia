using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;
using Microsoft.AspNetCore.Mvc;

namespace Company.Product.Module.Apis.Controllers
{
    [ApiController]
    [Security.Authorize]
    [Route("api/relatedSample")]
    public class RelatedSampleController(IRelatedSampleApplication relatedSampleApplication)
    {
        [HttpPost]
        public async Task<ResponseDto<GetRelatedSampleDto>> Create(CreateRelatedSampleDto createDto)
            => await relatedSampleApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetRelatedSampleDto>> Update(UpdateRelatedSampleDto updateDto)
            => await relatedSampleApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(Guid id)
            => await relatedSampleApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetRelatedSampleDto>> Get(Guid id)
            => await relatedSampleApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListRelatedSampleDto>>> List()
            => await relatedSampleApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchRelatedSampleDto>>> Search(SearchParamsDto<SearchRelatedSampleFilterDto> searchParams)
            => await relatedSampleApplication.Search(searchParams);
    }
}
