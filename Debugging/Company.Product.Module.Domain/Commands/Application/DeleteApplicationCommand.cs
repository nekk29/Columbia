using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Application
{
    public class DeleteApplicationCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
