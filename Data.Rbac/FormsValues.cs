using Data.Rbac.Bindings;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class FormsValues
    {
        [Key]
        [Column("UUID")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Layout]
        public string Value { get; set; }
        public bool IsDelete { get; set; }
        [DisplayFormat(DataFormatString = Setting.ymdhms)]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public Guid LayoutId { get; set; }
        [ForeignKey("LayoutId")]
        public virtual Forms Form { get; set; }
    }
}