using $safesolutionname$.Domain.Commands.Base;

namespace $safesolutionname$.Domain.Commands.Action
{
    public class DeleteActionCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
