using Company.Product.Module.Entity.Base;

namespace Company.Product.Module.Entity
{
    public partial class Module : SystemEntity
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
