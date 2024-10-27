using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Module;

namespace Company.Product.Module.RestClient.Abstractions
{
    public interface IModuleRestService
    {
        Task<ResponseDto<GetModuleDto>> Create(CreateModuleDto createDto);
        Task<ResponseDto<GetModuleDto>> Update(UpdateModuleDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetModuleDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListModuleDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchModuleDto>>> Search(SearchParamsDto<SearchModuleFilterDto> filter);
    }
}
