namespace $safesolutionname$.Entity
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaim>();
            Users = new HashSet<AspNetUser>();
        }

        public Guid Id { get; set; }
        public string CreationUser { get; set; } = null!;
        public DateTimeOffset CreationDate { get; set; }
        public string UpdateUser { get; set; } = null!;
        public DateTimeOffset UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }

        public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual ICollection<AspNetUser> Users { get; set; }
    }
}
