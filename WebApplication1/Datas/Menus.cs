using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Menus
    {
        public Menus()
        {
            InverseParent = new HashSet<Menus>();
            Pages = new HashSet<Pages>();
            RolesMenus = new HashSet<RolesMenus>();
        }

        public string Uuid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }
        public string ParentId { get; set; }
        public string Icon { get; set; }

        public virtual Menus Parent { get; set; }
        public virtual ICollection<Menus> InverseParent { get; set; }
        public virtual ICollection<Pages> Pages { get; set; }
        public virtual ICollection<RolesMenus> RolesMenus { get; set; }
    }
}
