using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;
using Company.Product.Module.RestClient.Abstractions;
using Company.Product.Module.RestClient.Base;

namespace Company.Product.Module.RestClient.Implementation
{
    public class RelatedSampleRestService(IServiceProvider serviceProvider) : BaseService(serviceProvider), IRelatedSampleRestService
    {
        protected override string ApiController => "api/relatedSample";

        public async Task<ResponseDto<GetRelatedSampleDto>> Create(CreateRelatedSampleDto createDto)
            => await Post<CreateRelatedSampleDto, ResponseDto<GetRelatedSampleDto>>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetRelatedSampleDto>> Update(UpdateRelatedSampleDto updateDto)
            => await Put<UpdateRelatedSampleDto, ResponseDto<GetRelatedSampleDto>>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(Guid id)
            => await Delete<ResponseDto>($"/{id}")!;

        public async Task<ResponseDto<GetRelatedSampleDto>> Get(Guid id)
            => await Get<ResponseDto<GetRelatedSampleDto>>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListRelatedSampleDto>>> List()
            => await Get<ResponseDto<IEnumerable<ListRelatedSampleDto>>>("/list")!;

        public async Task<ResponseDto<SearchResultDto<SearchRelatedSampleDto>>> Search(SearchParamsDto<SearchRelatedSampleFilterDto> filter)
            => await Post<SearchParamsDto<SearchRelatedSampleFilterDto>, ResponseDto<SearchResultDto<SearchRelatedSampleDto>>>("/search", filter)!;
    }
}
