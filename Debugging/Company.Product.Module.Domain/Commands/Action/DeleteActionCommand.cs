using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Action
{
    public class DeleteActionCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
