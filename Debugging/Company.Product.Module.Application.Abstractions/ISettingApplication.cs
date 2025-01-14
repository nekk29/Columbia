﻿using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;

namespace Company.Product.Module.Application.Abstractions
{
    public interface ISettingApplication
    {
        Task<ResponseDto<GetSettingDto>> Create(CreateSettingDto createDto);
        Task<ResponseDto<GetSettingDto>> Update(UpdateSettingDto updateDto);
        Task<ResponseDto> Delete(string group, string code);
        Task<ResponseDto<GetSettingDto>> Get(string group, string code);
        Task<ResponseDto<IEnumerable<ListSettingDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchSettingDto>>> Search(SearchParamsDto<SearchSettingFilterDto> searchParams);
    }
}
