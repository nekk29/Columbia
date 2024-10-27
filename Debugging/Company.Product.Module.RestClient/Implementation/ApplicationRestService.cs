using Company.Product.Module.Dto.Application;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.RestClient.Abstractions;
using Company.Product.Module.RestClient.Base;

namespace Company.Product.Module.RestClient.Implementation
{
    public class ApplicationRestService(IServiceProvider serviceProvider) : BaseService(serviceProvider), IApplicationRestService
    {
        protected override string ApiController => "api/application";

        public async Task<ResponseDto<GetApplicationDto>> Create(CreateApplicationDto createDto)
            => await Post<CreateApplicationDto, ResponseDto<GetApplicationDto>>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetApplicationDto>> Update(UpdateApplicationDto updateDto)
            => await Put<UpdateApplicationDto, ResponseDto<GetApplicationDto>>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(Guid id)
            => await Delete<ResponseDto>($"/{id}")!;

        public async Task<ResponseDto<GetApplicationDto>> Get(Guid id)
            => await Get<ResponseDto<GetApplicationDto>>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListApplicationDto>>> List()
            => await Get<ResponseDto<IEnumerable<ListApplicationDto>>>("/list")!;

        public async Task<ResponseDto<SearchResultDto<SearchApplicationDto>>> Search(SearchParamsDto<SearchApplicationFilterDto> filter)
            => await Post<SearchParamsDto<SearchApplicationFilterDto>, ResponseDto<SearchResultDto<SearchApplicationDto>>>("/search", filter)!;
    }
}
