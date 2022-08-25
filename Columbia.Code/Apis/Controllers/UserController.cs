using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace $safesolutionname$.Apis.Controllers
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
