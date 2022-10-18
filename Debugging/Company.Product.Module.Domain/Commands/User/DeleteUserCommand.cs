using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.User
{
    public class DeleteUserCommand : CommandBase
    {
        public DeleteUserCommand(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
