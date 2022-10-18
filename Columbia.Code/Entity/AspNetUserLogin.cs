namespace $safesolutionname$.Entity
{
    public partial class AspNetUserLogin
    {
        public Guid UserId { get; set; }
        public string LoginProvider { get; set; } = null!;
        public string ProviderKey { get; set; } = null!;
        public string? ProviderDisplayName { get; set; }

        public virtual AspNetUser User { get; set; } = null!;
    }
}
