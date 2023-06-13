using Microsoft.AspNetCore.Mvc;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Apis.Controllers
{
    [ApiController]
    [Route("api/role")]
    [Security.Authorize]
    public class RoleController
    {
        private readonly IRoleApplication _roleApplication;

        public RoleController(IRoleApplication roleApplication)
            => _roleApplication = roleApplication;

        [HttpPost]
        public async Task<ResponseDto<GetRoleDto>> Create(CreateRoleDto createDto)
            => await _roleApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetRoleDto>> Update(UpdateRoleDto updateDto)
            => await _roleApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(Guid id)
            => await _roleApplication.Delete(id);

        [HttpPut("inactivate/{id}")]
        public async Task<ResponseDto> Inactive(Guid id)
            => await _roleApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetRoleDto>> Get(Guid id)
            => await _roleApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListRoleDto>>> List()
            => await _roleApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchRoleDto>>> Search(SearchParamsDto<SearchRoleFilterDto> searchParams)
            => await _roleApplication.Search(searchParams);
    }
}
