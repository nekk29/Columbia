﻿using $safesolutionname$.Application.Abstractions;
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

        [HttpPost("login")]
        public async Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto)
            => await _userApplication.Login(loginDto);
    }
}
