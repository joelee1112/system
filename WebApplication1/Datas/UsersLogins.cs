using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class UsersLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
