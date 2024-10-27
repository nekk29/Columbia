namespace Company.Product.Module.Dto.Permission
{
    public class ListRolePermissionDto
    {
        public string ModuleCode { get; set; } = null!;
        public string ModuleName { get; set; } = null!;
        public IEnumerable<ListPermissionDto> Permissions { get; set; } = null!;
    }
}
