using Company.Product.Module.RestClient.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.RestClient
{
    public class RelatedSampleService : BaseService
    {
        protected override string ApiController => "api/relatedSample";

        public RelatedSampleService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetRelatedSampleDto>> Insert(CreateRelatedSampleDto createDto)
            => await Post<CreateRelatedSampleDto, GetRelatedSampleDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetRelatedSampleDto>> Update(UpdateRelatedSampleDto updateDto)
            => await Put<UpdateRelatedSampleDto, GetRelatedSampleDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetRelatedSampleDto>> Get(int id)
            => await Get<GetRelatedSampleDto>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListRelatedSampleDto>>> List()
            => await Get<IEnumerable<ListRelatedSampleDto>>("list")!;

        public async Task<ResponseDto<SearchResultDto<SearchRelatedSampleDto>>> Search(SearchParamsDto<SearchRelatedSampleFilterDto> filter)
            => await Post<SearchParamsDto<SearchRelatedSampleFilterDto>, SearchResultDto<SearchRelatedSampleDto>>("/search", filter)!;
    }
}
