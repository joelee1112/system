using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class RolesApis
    {
        public Guid ApiId { get; set; }
        public Guid RoleId { get; set; }

        [ForeignKey("ApiId")]
        public Apis Api { get; set; }
        [ForeignKey("RoleId")]
        public Roles Role { get; set; }
    }
}