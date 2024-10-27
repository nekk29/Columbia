using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Module
{
    public class DeleteModuleCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
