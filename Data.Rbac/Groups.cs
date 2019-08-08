using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class Groups: BaseEntity, IHierarchyEntity<Groups>
    {
        [Key]
        [Column("UUID")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }

        [ForeignKey("ParentId")]
        public Groups Parent { get; set; }
        public Guid? ParentId { get; set; }

        public ICollection<Groups> Children { get; set; }
        public ICollection<UsersGroups> UsersGroups { get; set; } = new HashSet<UsersGroups>();
        public ICollection<GroupsRoles> GroupsRoles { get; set; } = new HashSet<GroupsRoles>();

        public string GetTitle() => Name;
        public string GetTypeName() => "group";
        public Groups Clone() => new Groups
        {
            Id = Guid.NewGuid(),
            Name = this.Name
        };
        public void SetTitle(string v)
        {
            this.Name = v;
        }
    }
}
