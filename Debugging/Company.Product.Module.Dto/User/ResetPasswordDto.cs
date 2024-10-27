using Company.Product.Module.Dto.Base;

namespace Company.Product.Module.Dto.User
{
    public class ResetPasswordDto : ReturnUrlDto
    {
        public string Email { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? ConfirmPassword { get; set; } = null!;
    }
}
