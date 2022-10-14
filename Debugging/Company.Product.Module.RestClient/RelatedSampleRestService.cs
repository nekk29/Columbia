using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;
using Company.Product.Module.RestClient.Base;

namespace Company.Product.Module.RestClient
{
    public class RelatedSampleRestService : BaseService
    {
        protected override string ApiController => "api/relatedSample";

        public RelatedSampleRestService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetRelatedSampleDto>> Create(CreateRelatedSampleDto createDto)
            => await Post<CreateRelatedSampleDto, GetRelatedSampleDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetRelatedSampleDto>> Update(UpdateRelatedSampleDto updateDto)
            => await Put<UpdateRelatedSampleDto, GetRelatedSampleDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(Guid id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetRelatedSampleDto>> Get(Guid id)
            => await Get<GetRelatedSampleDto>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListRelatedSampleDto>>> List()
            => await Get<IEnumerable<ListRelatedSampleDto>>("/list")!;

        public async Task<ResponseDto<SearchResultDto<SearchRelatedSampleDto>>> Search(SearchParamsDto<SearchRelatedSampleFilterDto> filter)
            => await Post<SearchParamsDto<SearchRelatedSampleFilterDto>, SearchResultDto<SearchRelatedSampleDto>>("/search", filter)!;
    }
}
