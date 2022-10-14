using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;
using Microsoft.AspNetCore.Mvc;

namespace Company.Product.Module.Apis.Controllers
{
    [ApiController]
    [Route("api/relatedSample")]
    public class RelatedSampleController
    {
        private readonly IRelatedSampleApplication _relatedSampleApplication;

        public RelatedSampleController(IRelatedSampleApplication relatedSampleApplication)
            => _relatedSampleApplication = relatedSampleApplication;

        [HttpPost]
        public async Task<ResponseDto<GetRelatedSampleDto>> Create(CreateRelatedSampleDto createDto)
            => await _relatedSampleApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetRelatedSampleDto>> Update(UpdateRelatedSampleDto updateDto)
            => await _relatedSampleApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(Guid id)
            => await _relatedSampleApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetRelatedSampleDto>> Get(Guid id)
            => await _relatedSampleApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListRelatedSampleDto>>> List()
            => await _relatedSampleApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchRelatedSampleDto>>> Search(SearchParamsDto<SearchRelatedSampleFilterDto> searchParams)
            => await _relatedSampleApplication.Search(searchParams);
    }
}
