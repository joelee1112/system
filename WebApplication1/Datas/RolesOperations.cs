using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class RolesOperations
    {
        public string OperationId { get; set; }
        public string RoleId { get; set; }

        public virtual Operations Operation { get; set; }
        public virtual Roles Role { get; set; }
    }
}
