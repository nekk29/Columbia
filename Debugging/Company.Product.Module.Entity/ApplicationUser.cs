using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Product.Module.Entity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(100)]
        [Column("FirstName", TypeName = "varchar")]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("LastName", TypeName = "varchar")]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("CreationUser", TypeName = "varchar")]
        public string CreationUser { get; set; } = null!;

        [Required]
        public DateTimeOffset CreationDate { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("UpdateUser", TypeName = "varchar")]
        public string UpdateUser { get; set; } = null!;

        [Required]
        public DateTimeOffset UpdateDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
