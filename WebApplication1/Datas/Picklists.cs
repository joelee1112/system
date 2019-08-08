using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Picklists
    {
        public Picklists()
        {
            InverseParent = new HashSet<Picklists>();
        }

        public string Uuid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public short IsActive { get; set; }
        public short IsDelete { get; set; }
        public int Sequence { get; set; }
        public string ParentId { get; set; }

        public virtual Picklists Parent { get; set; }
        public virtual ICollection<Picklists> InverseParent { get; set; }
    }
}
