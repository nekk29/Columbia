using $safesolutionname$.Domain.Commands.Base;

namespace $safesolutionname$.Domain.Commands.Application
{
    public class DeleteApplicationCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
