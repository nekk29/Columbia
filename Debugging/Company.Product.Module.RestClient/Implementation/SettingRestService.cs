using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;
using Company.Product.Module.RestClient.Abstractions;
using Company.Product.Module.RestClient.Base;

namespace Company.Product.Module.RestClient.Implementation
{
    public class SettingRestService(IServiceProvider serviceProvider) : BaseService(serviceProvider), ISettingRestService
    {
        protected override string ApiController => "api/setting";

        public async Task<ResponseDto<GetSettingDto>> Create(CreateSettingDto createDto)
            => await Post<CreateSettingDto, ResponseDto<GetSettingDto>>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetSettingDto>> Update(UpdateSettingDto updateDto)
            => await Put<UpdateSettingDto, ResponseDto<GetSettingDto>>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete()
            => await Delete<ResponseDto>()!;

        public async Task<ResponseDto<GetSettingDto>> Get()
            => await Get<ResponseDto<GetSettingDto>>()!;

        public async Task<ResponseDto<IEnumerable<ListSettingDto>>> List()
            => await Get<ResponseDto<IEnumerable<ListSettingDto>>>("/list")!;

        public async Task<ResponseDto<SearchResultDto<SearchSettingDto>>> Search(SearchParamsDto<SearchSettingFilterDto> filter)
            => await Post<SearchParamsDto<SearchSettingFilterDto>, ResponseDto<SearchResultDto<SearchSettingDto>>>("/search", filter)!;
    }
}
