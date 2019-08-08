using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class SessionsRoles
    {
        public string RoleId { get; set; }
        public string SessionId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Sessions Session { get; set; }
    }
}
