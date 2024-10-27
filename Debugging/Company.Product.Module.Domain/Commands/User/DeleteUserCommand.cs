using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.User
{
    public class DeleteUserCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
