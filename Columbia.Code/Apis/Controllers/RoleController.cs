using Microsoft.AspNetCore.Mvc;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Apis.Controllers
{
    [ApiController]
    [Security.Authorize]
    [Route("api/role")]
    public class RoleController(IRoleApplication roleApplication)
    {
        [HttpPost]
        public async Task<ResponseDto<GetRoleDto>> Create(CreateRoleDto createDto)
            => await roleApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetRoleDto>> Update(UpdateRoleDto updateDto)
            => await roleApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(Guid id)
            => await roleApplication.Delete(id);

        [HttpPut("inactivate/{id}")]
        public async Task<ResponseDto> Inactive(Guid id)
            => await roleApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetRoleDto>> Get(Guid id)
            => await roleApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListRoleDto>>> List()
            => await roleApplication.List();

        [HttpGet("{applicationId}/list")]
        public async Task<ResponseDto<IEnumerable<ListRoleDto>>> List(Guid applicationId)
            => await roleApplication.List(applicationId);

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchRoleDto>>> Search(SearchParamsDto<SearchRoleFilterDto> searchParams)
            => await roleApplication.Search(searchParams);
    }
}
