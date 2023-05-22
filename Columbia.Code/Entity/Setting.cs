using $safesolutionname$.Entity.Base;

namespace $safesolutionname$.Entity
{
    public partial class Setting : SystemEntity
    {
        public string Group { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
