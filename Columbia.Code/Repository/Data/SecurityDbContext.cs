using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Entity;

namespace $safesolutionname$.Repository.Data
{
    public class SecurityDbContext(DbContextOptions<SecurityDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
    {

    }
}
