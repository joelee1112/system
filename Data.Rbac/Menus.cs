using Data.Rbac.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public partial class Menus : BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        [Display(Name = "流水號")]
        [Column("UUID")]
        public Guid Id { get; set; }

        [Required]
        [DataType("TextBox")]
        [Display(Name = "名稱")]
        [HideForEdit]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "排序")]
        public int Sequence { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "上一層代碼")]
        public Guid? ParentId { get; set; }

        [Display(Name = "圖示代碼")]
        public string Icon { get; set; }

        public virtual ICollection<Menus> Children { get; } = new HashSet<Menus>();
        [ForeignKey("ParentId")]
        public virtual Menus Parent { get; set; }

        public virtual ICollection<RolesMenus> RolesMenus { get; } = new HashSet<RolesMenus>();
        public virtual ICollection<Pages> Pages { get; } = new HashSet<Pages>();

        public Menus()
        {
            this.Id = Guid.NewGuid();
        }

        public Menus Clone()
        {
            return new Menus
            {
                Name = this.Name,
                Sequence = this.Sequence
            };
        }
    }
}
