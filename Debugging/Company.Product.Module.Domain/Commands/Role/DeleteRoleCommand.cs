using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Role
{
    public class DeleteRoleCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
