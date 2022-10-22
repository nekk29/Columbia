using Company.Product.Module.Entity.Base;

namespace Company.Product.Module.Entity
{
    public partial class Permission : SystemEntity
    {
        public Guid Id { get; set; }
        public Guid AspNetRoleId { get; set; }
        public Guid ActionId { get; set; }

        public virtual Action Action { get; set; } = null!;
        public virtual AspNetRole AspNetRole { get; set; } = null!;
    }
}
