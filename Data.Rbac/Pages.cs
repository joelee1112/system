using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class Pages : BaseEntity
    {
        [Key]
        [Column("UUID")]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? MenuId { get; set; }
        [DataType("TextBox")]
        [Display(Name = "連結", Prompt = "請輸入網址")]
        public string Url { get; set; }
        public int Sequence { get; set; }
        [Display(Name = "圖示代碼")]
        public string Icon { get; set; }

        [ForeignKey("MenuId")]
        public Menus Menu { get; set; }
        [ForeignKey("ParentId")]
        public Pages Parent { get; set; }

        public ICollection<Pages> Children { get; set; } = new HashSet<Pages>();
        public ICollection<Apis> Apis { get; set; } = new HashSet<Apis>();
        public ICollection<Operations> Operations { get; set; } = new HashSet<Operations>();
        public ICollection<RolesPages> RolesPages { get; set; } = new HashSet<RolesPages>();

        public Pages Clone()
        {
            return new Pages
            {
                Name = this.Name,
                Url = this.Url,
                Sequence = this.Sequence
            };
        }
    }
}
