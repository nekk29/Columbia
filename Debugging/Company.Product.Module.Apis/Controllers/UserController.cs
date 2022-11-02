using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Product.Module.Apis.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Security.Authorize]
    public class UserController
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
            => _userApplication = userApplication;

        [HttpPost]
        public async Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto)
            => await _userApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetUserDto>> Update(UpdateUserDto updateDto)
            => await _userApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(Guid id)
            => await _userApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetUserDto>> Get(Guid id)
            => await _userApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListUserDto>>> List()
            => await _userApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchUserDto>>> Search(SearchParamsDto<SearchUserFilterDto> searchParams)
            => await _userApplication.Search(searchParams);

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto)
            => await _userApplication.Login(loginDto);

        [AllowAnonymous]
        [HttpGet("forgot-password/{email}")]
        public async Task<ResponseDto> ForgotPassword(string email)
            => await _userApplication.ForgotPassword(email);

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<ResponseDto> ResetPassword(ResetPasswordDto resetPasswordDto)
            => await _userApplication.ResetPassword(resetPasswordDto);
    }
}
