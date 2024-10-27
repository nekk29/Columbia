using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Dto.User
{
    public class LoginDto : ReturnUrlDto
    {
        public string ApplicationCode { get; set; } = null!;
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
