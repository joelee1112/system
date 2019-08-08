using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class SessionsRoles
    {
        public Guid RoleId { get; set; }
        public Guid SessionId { get; set; }

        [ForeignKey("RoleId")]
        public Roles Role { get; set; }
        [ForeignKey("SessionId")]
        public Sessions Session { get; set; }
    }
}
