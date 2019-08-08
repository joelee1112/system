using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;

namespace Data.Rbac
{
    public partial class UsersRoles : IdentityUserRole<Guid>
    {
        [Description("0:審核中，1:通過，2:未通過")]
        public sbyte Status { get; set; }
        public string Reason { get; set; }
    }
}
