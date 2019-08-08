using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Groups
    {
        public Groups()
        {
            GroupsRoles = new HashSet<GroupsRoles>();
            InverseParent = new HashSet<Groups>();
            UsersGroups = new HashSet<UsersGroups>();
        }

        public string Uuid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }
        public string ParentId { get; set; }

        public virtual Groups Parent { get; set; }
        public virtual ICollection<GroupsRoles> GroupsRoles { get; set; }
        public virtual ICollection<Groups> InverseParent { get; set; }
        public virtual ICollection<UsersGroups> UsersGroups { get; set; }
    }
}
