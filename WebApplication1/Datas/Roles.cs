using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Roles
    {
        public Roles()
        {
            GroupsRoles = new HashSet<GroupsRoles>();
            InverseParent = new HashSet<Roles>();
            RolesApis = new HashSet<RolesApis>();
            RolesClaims = new HashSet<RolesClaims>();
            RolesMenus = new HashSet<RolesMenus>();
            RolesOperations = new HashSet<RolesOperations>();
            RolesPages = new HashSet<RolesPages>();
            SessionsRoles = new HashSet<SessionsRoles>();
            UsersRoles = new HashSet<UsersRoles>();
        }

        public string Uuid { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Description { get; set; }
        public short IsDelete { get; set; }
        public string ParentId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public int Sequence { get; set; }

        public virtual Roles Parent { get; set; }
        public virtual ICollection<GroupsRoles> GroupsRoles { get; set; }
        public virtual ICollection<Roles> InverseParent { get; set; }
        public virtual ICollection<RolesApis> RolesApis { get; set; }
        public virtual ICollection<RolesClaims> RolesClaims { get; set; }
        public virtual ICollection<RolesMenus> RolesMenus { get; set; }
        public virtual ICollection<RolesOperations> RolesOperations { get; set; }
        public virtual ICollection<RolesPages> RolesPages { get; set; }
        public virtual ICollection<SessionsRoles> SessionsRoles { get; set; }
        public virtual ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
