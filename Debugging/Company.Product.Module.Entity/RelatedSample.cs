using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Product.Module.Entity
{
   public class RelatedSample
   {
      [Key]
      public Guid Id { get; set; }
      public string Code { get; set; } = null!;
      public string Description { get; set; } = null!;
   }
}
