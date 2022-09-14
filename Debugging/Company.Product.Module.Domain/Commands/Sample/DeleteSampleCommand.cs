using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class DeleteSampleCommand : CommandBase
    {
        public DeleteSampleCommand(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
