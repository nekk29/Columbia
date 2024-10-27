using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.MenuOption
{
    public class DeleteMenuOptionCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
