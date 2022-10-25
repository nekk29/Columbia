namespace $safesolutionname$.Dto.MenuOption
{
    public class ListMenuOptionDto : MenuOptionDto
    {
        public Guid? ParentId { get; set; }
        public string ParentCode { get; set; } = null!;
        public string ParentName { get; set; } = null!;
    }
}
