using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Role
{
    public class DeleteRoleCommand : CommandBase
    {
        public DeleteRoleCommand(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
