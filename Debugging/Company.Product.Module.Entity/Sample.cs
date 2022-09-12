using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Company.Product.Module.Entity.Base;

namespace Company.Product.Module.Entity
{
   public class Sample : SystemEntity
   {
      [Key]
      public Guid Id { get; set; }
      [ForeignKey("RelatedSampleId")]
      public virtual RelatedSample RelatedSample { get; set; } = null!;
      public Guid RelatedSampleId { get; set; }
      public string Code { get; set; } = null!;
      public string Description { get; set; } = null!;
      public string? Remarks { get; set; } 
   }
}
