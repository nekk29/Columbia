namespace Company.Product.Module.Dto.Role
{
    public class SearchRoleDto : RoleDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
