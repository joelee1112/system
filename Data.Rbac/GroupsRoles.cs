using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class GroupsRoles
    {
        [ForeignKey("GroupId")]
        public Groups Group { get; set; }
        public Guid GroupId { get; set; }

        [ForeignKey("RoleId")]
        public Roles Role { get; set; }
        public Guid RoleId { get; set; }
    }
}