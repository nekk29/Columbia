using Microsoft.AspNetCore.Identity;

namespace Company.Product.Module.Entity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public bool Active { get; set; }
    }
}
