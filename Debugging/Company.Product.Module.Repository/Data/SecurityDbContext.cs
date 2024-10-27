using Company.Product.Module.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Repository.Data
{
    public class SecurityDbContext(DbContextOptions<SecurityDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
    {

    }
}
