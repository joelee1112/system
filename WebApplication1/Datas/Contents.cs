using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Contents
    {
        public Contents()
        {
            InverseParent = new HashSet<Contents>();
        }

        public string Uuid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Title { get; set; }
        public string ViewName { get; set; }
        public string Identity { get; set; }
        public string Html { get; set; }
        public string Description { get; set; }
        public DateTime? PostTime { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string ThumbUrl { get; set; }
        public string ImageUrl { get; set; }
        public int? SortValue { get; set; }
        public string Url { get; set; }
        public int Sequence { get; set; }
        public string ParentId { get; set; }
        public short? IsTop { get; set; }
        public short? IsFooter { get; set; }
        public short? IsEnable { get; set; }
        public short? IsAgent { get; set; }
        public string FileUrl { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public byte? ContentType { get; set; }

        public virtual Contents Parent { get; set; }
        public virtual ICollection<Contents> InverseParent { get; set; }
    }
}
