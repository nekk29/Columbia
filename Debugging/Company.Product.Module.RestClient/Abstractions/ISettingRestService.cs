using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;

namespace Company.Product.Module.RestClient.Abstractions
{
    public interface ISettingRestService
    {
        Task<ResponseDto<GetSettingDto>> Create(CreateSettingDto createDto);
        Task<ResponseDto<GetSettingDto>> Update(UpdateSettingDto updateDto);
        Task<ResponseDto> Delete();
        Task<ResponseDto<GetSettingDto>> Get();
        Task<ResponseDto<IEnumerable<ListSettingDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchSettingDto>>> Search(SearchParamsDto<SearchSettingFilterDto> filter);
    }
}
