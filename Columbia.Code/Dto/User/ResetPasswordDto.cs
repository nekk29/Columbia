using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Dto.User
{
    public class ResetPasswordDto : ReturnUrlDto
    {
        public string Email { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? ConfirmPassword { get; set; } = null!;
    }
}
