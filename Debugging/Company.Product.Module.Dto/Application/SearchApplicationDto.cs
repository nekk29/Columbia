namespace Company.Product.Module.Dto.Application
{
    public class SearchApplicationDto : ApplicationDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
