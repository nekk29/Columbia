using Company.Product.Module.Dto.Application;
using Company.Product.Module.Dto.Base;

namespace Company.Product.Module.RestClient.Abstractions
{
    public interface IApplicationRestService
    {
        Task<ResponseDto<GetApplicationDto>> Create(CreateApplicationDto createDto);
        Task<ResponseDto<GetApplicationDto>> Update(UpdateApplicationDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetApplicationDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListApplicationDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchApplicationDto>>> Search(SearchParamsDto<SearchApplicationFilterDto> filter);
    }
}
