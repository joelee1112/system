using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class RolesApis
    {
        public string ApiId { get; set; }
        public string RoleId { get; set; }

        public virtual Apis Api { get; set; }
        public virtual Roles Role { get; set; }
    }
}
