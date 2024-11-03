using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;
using Company.Product.Module.RestClient.Abstractions;
using Company.Product.Module.RestClient.Base;

namespace Company.Product.Module.RestClient.Implementation
{
    public class SampleRestService(IServiceProvider serviceProvider) : BaseService(serviceProvider), ISampleRestService
    {
        protected override string ApiController => "api/sample";

        public async Task<ResponseDto<GetSampleDto>> Create(CreateSampleDto createDto)
            => await Post<CreateSampleDto, ResponseDto<GetSampleDto>>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetSampleDto>> Update(UpdateSampleDto updateDto)
            => await Put<UpdateSampleDto, ResponseDto<GetSampleDto>>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(Guid id)
            => await Delete<ResponseDto>($"/{id}")!;

        public async Task<ResponseDto<GetSampleDto>> Get(Guid id)
            => await Get<ResponseDto<GetSampleDto>>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListSampleDto>>> List()
            => await Get<ResponseDto<IEnumerable<ListSampleDto>>>("/list")!;

        public async Task<ResponseDto<SearchResultDto<SearchSampleDto>>> Search(SearchParamsDto<SearchSampleFilterDto> filter)
            => await Post<SearchParamsDto<SearchSampleFilterDto>, ResponseDto<SearchResultDto<SearchSampleDto>>>("/search", filter)!;
    }
}
