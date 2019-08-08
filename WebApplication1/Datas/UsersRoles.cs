using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class UsersRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public byte Status { get; set; }
        public string Reason { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
