using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class GroupsRoles
    {
        public string GroupId { get; set; }
        public string RoleId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Roles Role { get; set; }
    }
}
