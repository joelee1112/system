using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class RolesClaims
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual Roles Role { get; set; }
    }
}
