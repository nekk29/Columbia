using System;

namespace Company.Product.Module.Dto.Sample
{
   public class SearchSampleFilterDto
   {
      public Guid? Id { get; set; } = null!;
      public Guid? RelatedId { get; set; } = null!;
      public string? Code { get; set; } = null!;
      public string? Description { get; set; } = null!;
      public string? Remarks { get; set; } = null!;
   }
}
