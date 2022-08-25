using Microsoft.AspNetCore.Identity;

namespace $safesolutionname$.Entity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public bool Active { get; set; }
    }
}
