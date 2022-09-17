using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Company.Product.Module.Entity
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
