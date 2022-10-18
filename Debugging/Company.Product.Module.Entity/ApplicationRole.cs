using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Product.Module.Entity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
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
