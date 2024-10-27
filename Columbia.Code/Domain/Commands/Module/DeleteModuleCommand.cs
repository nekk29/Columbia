using $safesolutionname$.Domain.Commands.Base;

namespace $safesolutionname$.Domain.Commands.Module
{
    public class DeleteModuleCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
