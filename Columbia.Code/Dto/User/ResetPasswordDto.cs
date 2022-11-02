namespace $safesolutionname$.Dto.User
{
    public class ResetPasswordDto
    {
        public string Email { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? ConfirmPassword { get; set; } = null!;
    }
}
