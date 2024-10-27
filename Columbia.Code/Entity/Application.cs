using $safesolutionname$.Entity.Base;

namespace $safesolutionname$.Entity
{
    public class Application : SystemEntity
    {
        public Application()
        {
            Modules = new HashSet<Module>();
            MenuOptions = new HashSet<MenuOption>();
            Roles = new HashSet<AspNetRole>();
        }

        public Guid Id { get; set; }
        public string? ClientId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? LogoUri { get; set; } = null!;
        public string? ApplicationUri { get; set; } = null!;

        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<MenuOption> MenuOptions { get; set; }
        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}
