using $safesolutionname$.Entity.Base;

namespace $safesolutionname$.Entity
{
    public partial class Module: SystemEntity
    {
        public Module()
        {
            Actions = new HashSet<Action>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
    }
}
