using System;

namespace Company.Product.Module.Dto.Sample
{
   public class SampleDto
   {
      public Guid RelatedSampleId { get; set; }
      public string Code { get; set; } = null!;
      public string Description { get; set; } = null!;
      public string? Remarks { get; set; } 
   }
}
