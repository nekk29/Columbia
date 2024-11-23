using IdentityServer4;
using IdentityServer4.Events;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Common;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Apis.Controllers
{
    [ApiController]
    [Security.Authorize]
    [Route("api/user")]
    public class UserController(
        IEventService eventService,
        IConfiguration configuration,
        IUserApplication userApplication,
        IIdentityServerInteractionService interaction
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto)
            => await userApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetUserDto>> Update(UpdateUserDto updateDto)
            => await userApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(Guid id)
            => await userApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetUserDto>> Get(Guid id)
            => await userApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListUserDto>>> List()
            => await userApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchUserDto>>> Search(SearchParamsDto<SearchUserFilterDto> searchParams)
            => await userApplication.Search(searchParams);

        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult Login([FromQuery] string returnUrl)
        {
            var returnUrlParam = string.IsNullOrEmpty(returnUrl) ? string.Empty : $"?returnUrl={UriUtils.EncodeUri(returnUrl)}";
            var frontUrl = configuration.GetValue<string>("SecurityOptions:FrontUrl");
            return RedirectPermanent($"{frontUrl}/user/login{returnUrlParam}");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [EnableCors("login")]
        public async Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto)
            => await userApplication.Login(loginDto);

        [HttpGet("logout")]
        public async Task Logout([FromQuery] string id_token_hint)
        {
            var context = await interaction.GetLogoutContextAsync(id_token_hint);
            if (context != null)
            {
                await eventService.RaiseAsync(new UserLogoutSuccessEvent(context.SubjectId, context.ClientName));
                await HttpContext.SignOutAsync(IdentityServerConstants.DefaultCookieAuthenticationScheme);
                await HttpContext.SignOutAsync();
            }
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<ResponseDto> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
            => await userApplication.ForgotPassword(forgotPasswordDto);

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<ResponseDto> ResetPassword(ResetPasswordDto resetPasswordDto)
            => await userApplication.ResetPassword(resetPasswordDto);
    }
}
