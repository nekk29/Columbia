using $safesolutionname$.Domain.Commands.Base;

namespace $safesolutionname$.Domain.Commands.User
{
    public class DeleteUserCommand : CommandBase
    {
        public DeleteUserCommand(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
