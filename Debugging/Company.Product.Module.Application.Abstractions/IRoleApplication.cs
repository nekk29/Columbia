using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Role;

namespace Company.Product.Module.Application.Abstractions
{
    public interface IRoleApplication
    {
        Task<ResponseDto<GetRoleDto>> Create(CreateRoleDto createDto);
        Task<ResponseDto<GetRoleDto>> Update(UpdateRoleDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetRoleDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListRoleDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchRoleDto>>> Search(SearchParamsDto<SearchRoleFilterDto> searchParams);
    }
}
