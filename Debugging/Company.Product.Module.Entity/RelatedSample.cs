using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Company.Product.Module.Entity.Base;

namespace Company.Product.Module.Entity
{
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
