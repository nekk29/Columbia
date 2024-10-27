using $safesolutionname$.Domain.Commands.Base;

namespace $safesolutionname$.Domain.Commands.Role
{
    public class DeleteRoleCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
