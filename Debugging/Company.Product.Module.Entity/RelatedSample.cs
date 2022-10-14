using Company.Product.Module.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Product.Module.Entity
{
    [Table("RelatedSamples")]
    public class RelatedSample : SystemEntity
    {
        public RelatedSample()
        {
            Samples = new HashSet<Sample>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Sample> Samples { get; set; }
    }
}
