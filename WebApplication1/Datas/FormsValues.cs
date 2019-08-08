using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class FormsValues
    {
        public string Uuid { get; set; }
        public string Value { get; set; }
        public short IsDelete { get; set; }
        public DateTime CreateTime { get; set; }
        public string LayoutId { get; set; }

        public virtual Forms Layout { get; set; }
    }
}
