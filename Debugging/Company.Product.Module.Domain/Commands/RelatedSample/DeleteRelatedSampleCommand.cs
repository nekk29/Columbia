using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class DeleteRelatedSampleCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
