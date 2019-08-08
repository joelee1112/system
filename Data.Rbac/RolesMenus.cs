using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class RolesMenus
    {
        [ForeignKey("MenuId")]
        public Menus Menu { get; set; }
        public Guid MenuId { get; set; }

        [ForeignKey("RoleId")]
        public Roles Role { get; set; }
        public Guid RoleId { get; set; }
    }
}