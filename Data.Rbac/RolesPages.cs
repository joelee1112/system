using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class RolesPages
    {
        public Guid PageId { get; set; }
        public Guid RoleId { get; set; }

        [ForeignKey("PageId")]
        public Pages Page { get; set; }
        [ForeignKey("RoleId")]
        public Roles Role { get; set; }
    }
}