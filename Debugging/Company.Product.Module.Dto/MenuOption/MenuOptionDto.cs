namespace Company.Product.Module.Dto.MenuOption
{
    public class MenuOptionDto
    {
        public Guid Id { get; set; }
        public Guid ModuleId { get; set; }
        public string ModuleCode { get; set; } = null!;
        public string ModuleName { get; set; } = null!;
        public Guid ActionId { get; set; }
        public string ActionCode { get; set; } = null!;
        public string ActionName { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string MenuUri { get; set; } = null!;
        public string MenuIcon { get; set; } = null!;
        public int SortOrder { get; set; }
        public bool Enabled { get; set; }
    }
}
