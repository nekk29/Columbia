using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Application.Abstractions
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
