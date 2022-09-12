using System;

namespace $safesolutionname$.Entity.Base
{
    public class SystemEntity
    {
        public string CreationUser { get; set; } = null!;
        public DateTimeOffset CreationDate { get; set; }
        public string UpdateUser { get; set; } = null!;
        public DateTimeOffset UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
