using Microsoft.AspNetCore.Mvc;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.Apis.Controllers
{
    [ApiController]
    [Route("api/menu-option")]
    [Security.Authorize]
    public class MenuOptionController
    {
        private readonly IMenuOptionApplication _menuOptionApplication;

        public MenuOptionController(IMenuOptionApplication menuOptionApplication)
            => _menuOptionApplication = menuOptionApplication;

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> List()
            => await _menuOptionApplication.List();

        [HttpGet("tree")]
        public async Task<ResponseDto<IEnumerable<TreeMenuOptionDto>>> Tree()
            => await _menuOptionApplication.Tree();
    }
}
