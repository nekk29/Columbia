using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Company.Product.Module.Entity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        [Required]
        [MaxLength(64)]
        public string CreationUser { get; set; } = null!;

        [Required]
        public DateTimeOffset CreationDate { get; set; }

        [Required]
        [MaxLength(64)]
        public string UpdateUser { get; set; } = null!;

        [Required]
        public DateTimeOffset UpdateDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
