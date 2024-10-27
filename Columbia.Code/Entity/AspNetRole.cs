using $safesolutionname$.Entity.Base;

namespace $safesolutionname$.Entity
{
    public partial class AspNetRole : SystemEntity
    {
        public AspNetRole()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaim>();
            Permissions = new HashSet<Permission>();
            Users = new HashSet<AspNetUser>();
        }

        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public string Name { get; set; } = null!;
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }

        public virtual Application Application { get; set; } = null!;
        public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<AspNetUser> Users { get; set; }
    }
}
