using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class UsersTokens
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Users User { get; set; }
    }
}
