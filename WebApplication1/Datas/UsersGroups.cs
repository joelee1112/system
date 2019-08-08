using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class UsersGroups
    {
        public string GroupId { get; set; }
        public string UserId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Users User { get; set; }
    }
}
