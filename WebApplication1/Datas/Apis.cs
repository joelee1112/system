using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Apis
    {
        public Apis()
        {
            RolesApis = new HashSet<RolesApis>();
        }

        public string Uuid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Name { get; set; }
        public string PageId { get; set; }
        public string OperationId { get; set; }
        public string Url { get; set; }
        public int Sequence { get; set; }

        public virtual Operations Operation { get; set; }
        public virtual Pages Page { get; set; }
        public virtual ICollection<RolesApis> RolesApis { get; set; }
    }
}
