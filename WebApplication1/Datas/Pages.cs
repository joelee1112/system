using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Pages
    {
        public Pages()
        {
            Apis = new HashSet<Apis>();
            InverseParent = new HashSet<Pages>();
            Operations = new HashSet<Operations>();
            RolesPages = new HashSet<RolesPages>();
        }

        public string Uuid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string MenuId { get; set; }
        public string Url { get; set; }
        public int Sequence { get; set; }
        public string Icon { get; set; }

        public virtual Menus Menu { get; set; }
        public virtual Pages Parent { get; set; }
        public virtual ICollection<Apis> Apis { get; set; }
        public virtual ICollection<Pages> InverseParent { get; set; }
        public virtual ICollection<Operations> Operations { get; set; }
        public virtual ICollection<RolesPages> RolesPages { get; set; }
    }
}
