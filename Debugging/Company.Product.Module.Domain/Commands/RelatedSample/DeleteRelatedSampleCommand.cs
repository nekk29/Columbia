using Company.Product.Module.Domain.Commands.Base;
namespace Company.Product.Module.Domain.Commands.RelatedSample
{
    public class DeleteRelatedSampleCommand : CommandBase
    {
        public DeleteRelatedSampleCommand(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
