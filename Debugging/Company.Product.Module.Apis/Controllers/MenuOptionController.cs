using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.MenuOption;
using Microsoft.AspNetCore.Mvc;

namespace Company.Product.Module.Apis.Controllers
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
