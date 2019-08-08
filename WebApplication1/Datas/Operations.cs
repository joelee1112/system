using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Operations
    {
        public Operations()
        {
            Apis = new HashSet<Apis>();
            RolesOperations = new HashSet<RolesOperations>();
        }

        public string Uuid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Name { get; set; }
        public string PageId { get; set; }
        public int Sequence { get; set; }

        public virtual Pages Page { get; set; }
        public virtual ICollection<Apis> Apis { get; set; }
        public virtual ICollection<RolesOperations> RolesOperations { get; set; }
    }
}
