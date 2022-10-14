using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;
using Company.Product.Module.RestClient.Base;

namespace Company.Product.Module.RestClient
{
    public class SampleRestService : BaseService
    {
        protected override string ApiController => "api/sample";

        public SampleRestService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetSampleDto>> Create(CreateSampleDto createDto)
            => await Post<CreateSampleDto, GetSampleDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetSampleDto>> Update(UpdateSampleDto updateDto)
            => await Put<UpdateSampleDto, GetSampleDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(Guid id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetSampleDto>> Get(Guid id)
            => await Get<GetSampleDto>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListSampleDto>>> List()
            => await Get<IEnumerable<ListSampleDto>>("/list")!;

        public async Task<ResponseDto<SearchResultDto<SearchSampleDto>>> Search(SearchParamsDto<SearchSampleFilterDto> filter)
            => await Post<SearchParamsDto<SearchSampleFilterDto>, SearchResultDto<SearchSampleDto>>("/search", filter)!;
    }
}
