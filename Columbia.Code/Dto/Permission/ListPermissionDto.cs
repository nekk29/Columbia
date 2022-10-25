namespace $safesolutionname$.Dto.Permission
{
    public class ListPermissionDto
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public Guid ActionId { get; set; }
        public string ActionCode { get; set; } = null!;
        public string ActionName { get; set; } = null!;
    }
}
