using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Dto.User
{
    public class ForgotPasswordDto : ReturnUrlDto
    {
        public string Email { get; set; } = null!;
    }
}
