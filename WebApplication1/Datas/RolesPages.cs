using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class RolesPages
    {
        public string PageId { get; set; }
        public string RoleId { get; set; }

        public virtual Pages Page { get; set; }
        public virtual Roles Role { get; set; }
    }
}
