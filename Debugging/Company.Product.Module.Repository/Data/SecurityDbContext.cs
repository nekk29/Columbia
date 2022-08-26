using Company.Product.Module.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Repository.Data
{
    public class SecurityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {

        }
    }
}
