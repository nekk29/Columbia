using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace Company.Product.Module.Apis.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
            => _userApplication = userApplication;

        [HttpPost]
        public async Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto)
            => await _userApplication.Create(createDto);

        [HttpPost("login")]
        public async Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto)
            => await _userApplication.Login(loginDto);
    }
}
