using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Forms
    {
        public Forms()
        {
            FormsValues = new HashSet<FormsValues>();
        }

        public string Uuid { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public short IsDelete { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual ICollection<FormsValues> FormsValues { get; set; }
    }
}
