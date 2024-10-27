using $safesolutionname$.Domain.Commands.Base;

namespace $safesolutionname$.Domain.Command.Permission
{
    public class AssignPermissionsCommand(Guid roleId, IEnumerable<Guid> actionIds) : CommandBase
    {
        public Guid RoleId { get; set; } = roleId;
        public IEnumerable<Guid> ActionIds { get; set; } = actionIds;
    }
}
