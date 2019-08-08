using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class UsersClaims
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual Users User { get; set; }
    }
}
