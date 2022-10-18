using $safesolutionname$.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace $safesolutionname$.Repository.Data
{
    public class SecurityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {

        }
    }
}
