using $safesolutionname$.Domain.Commands.Base;

namespace $safesolutionname$.Domain.Commands.User
{
    public class DeleteUserCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
