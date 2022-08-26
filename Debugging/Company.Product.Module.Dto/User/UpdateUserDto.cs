namespace Company.Product.Module.Dto.User
{
    public class UpdateUserDto : UserDto
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }
}
