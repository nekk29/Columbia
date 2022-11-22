using Company.Product.Module.Entity.Base;

namespace Company.Product.Module.Entity
{
    public class Email : SystemEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string? ToEmails { get; set; }
        public string? CcEmails { get; set; }
        public string Body { get; set; } = null!;
    }
}
