﻿using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.RestClient.Abstractions
{
    public interface IRelatedSampleRestService
    {
        Task<ResponseDto<GetRelatedSampleDto>> Create(CreateRelatedSampleDto createDto);
        Task<ResponseDto<GetRelatedSampleDto>> Update(UpdateRelatedSampleDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetRelatedSampleDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListRelatedSampleDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchRelatedSampleDto>>> Search(SearchParamsDto<SearchRelatedSampleFilterDto> filter);
    }
}
