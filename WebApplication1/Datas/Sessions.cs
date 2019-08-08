using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Sessions
    {
        public Sessions()
        {
            SessionsRoles = new HashSet<SessionsRoles>();
        }

        public string Uuid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime ExpireTime { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<SessionsRoles> SessionsRoles { get; set; }
    }
}
