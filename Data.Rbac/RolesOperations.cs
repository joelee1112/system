using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class RolesOperations
    {
        public Guid OperationId { get; set; }
        public Guid RoleId { get; set; }

        [ForeignKey("OperationId")]
        public Operations Operation { get; set; }
        [ForeignKey("RoleId")]
        public Roles Role { get; set; }
    }
}