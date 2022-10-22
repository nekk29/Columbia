using $safesolutionname$.Entity.Base;

namespace $safesolutionname$.Entity
{
    public partial class Permission : SystemEntity
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid ActionId { get; set; }

        public virtual Action Action { get; set; } = null!;
        public virtual AspNetRole Role { get; set; } = null!;
    }
}
