using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Product.Module.Entity
{
   public class Sample
   {
      [Key]
      public Guid Id { get; set; }
      [ForeignKey("RelatedSampleId")]
      public RelatedSample RelatedSample { get; set; } = null!;
      public Guid RelatedSampleId { get; set; }
      public string Code { get; set; } = null!;
      public string Description { get; set; } = null!;
      public string? Remarks { get; set; } 
   }
}
