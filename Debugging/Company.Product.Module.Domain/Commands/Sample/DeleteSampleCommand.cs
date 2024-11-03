using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Sample
{
    public class DeleteSampleCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
