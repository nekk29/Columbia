using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Product.Module.Entity
{
   [Table("Samples")]
   public class Sample
   {
      [Key]
      public Guid Id { get; set; }
      [ForeignKey("RelatedId")]
      public virtual RelatedSample RelatedSample { get; set; } = null!;
      public Guid RelatedId { get; set; }
      public string Code { get; set; } = null!;
      public string Description { get; set; } = null!;
      [Column("Comments")]
      public string? Remarks { get; set; } = null!;
   }
}
