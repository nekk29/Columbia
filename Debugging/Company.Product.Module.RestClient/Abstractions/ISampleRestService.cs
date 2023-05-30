using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.RestClient.Abstractions
{
    public interface ISampleRestService
    {
        Task<ResponseDto<GetSampleDto>> Create(CreateSampleDto createDto);
        Task<ResponseDto<GetSampleDto>> Update(UpdateSampleDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetSampleDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListSampleDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchSampleDto>>> Search(SearchParamsDto<SearchSampleFilterDto> filter);
    }
}
