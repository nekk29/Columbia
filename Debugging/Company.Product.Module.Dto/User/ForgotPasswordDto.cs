using Company.Product.Module.Dto.Base;

namespace Company.Product.Module.Dto.User
{
    public class ForgotPasswordDto : ReturnUrlDto
    {
        public string Email { get; set; } = null!;
    }
}
