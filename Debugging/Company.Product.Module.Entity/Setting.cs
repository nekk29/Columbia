using Company.Product.Module.Entity.Base;

namespace Company.Product.Module.Entity
{
    public partial class Setting : SystemEntity
    {
        public string Group { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
