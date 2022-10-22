﻿using $safesolutionname$.Entity.Base;

namespace $safesolutionname$.Entity
{
    public partial class Action : SystemEntity
    {
        public Action()
        {
            MenuOptions = new HashSet<MenuOption>();
            Permissions = new HashSet<Permission>();
        }

        public Guid Id { get; set; }
        public Guid ModuleId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual Module Module { get; set; } = null!;
        public virtual ICollection<MenuOption> MenuOptions { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
