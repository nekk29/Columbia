namespace Company.Product.Module.Dto.User
{
    public class CreateUserDto : UserDto
    {
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
