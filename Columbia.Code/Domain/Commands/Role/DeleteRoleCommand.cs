using $safesolutionname$.Domain.Commands.Base;

namespace $safesolutionname$.Domain.Commands.Role
{
    public class DeleteRoleCommand : CommandBase
    {
        public DeleteRoleCommand(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
