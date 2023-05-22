using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;

namespace Company.Product.Module.Application.Abstractions
{
    public interface ISettingApplication
    {
        Task<ResponseDto<GetSettingDto>> Update(UpdateSettingDto updateDto);
        Task<ResponseDto<GetSettingDto>> Get(string group, string code);
        Task<ResponseDto<SearchResultDto<SearchSettingDto>>> Search(SearchParamsDto<SearchSettingFilterDto> searchParams);
    }
}
