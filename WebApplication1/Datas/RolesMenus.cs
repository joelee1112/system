using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class RolesMenus
    {
        public string MenuId { get; set; }
        public string RoleId { get; set; }

        public virtual Menus Menu { get; set; }
        public virtual Roles Role { get; set; }
    }
}
