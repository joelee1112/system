using Data.Rbac.Bindings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Rbac
{
    [ModelMetadataType(typeof(RolesTypes))]
    public class Roles : IdentityRole<Guid>, IHierarchyEntity<Roles>
    {
        public Roles()
        {
            this.Id = Guid.NewGuid();
        }

        public string Description { get; set; }
        [HideForEdit]
        [HideForDisplay]
        public bool IsDelete { get; set; }
        [HideForEdit]
        [HideForDisplay]
        public Guid? ParentId { get; set; }
        [HideForEdit]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        [HideForEdit]
        public DateTime? ModifyTime { get; set; }
        public int Sequence { get; set; }

        [ForeignKey("ParentId")]
        public Roles Parent { get; set; }
        public virtual ICollection<UsersRoles> Users { get; set; } = new HashSet<UsersRoles>();
        public virtual ICollection<Roles> Children { get; set; } = new HashSet<Roles>();
        public virtual ICollection<SessionsRoles> SessionsRoles { get; set; } = new HashSet<SessionsRoles>();
        public ICollection<RolesMenus> RolesMenus { get; set; } = new HashSet<RolesMenus>();
        public ICollection<RolesPages> RolesPages { get; set; } = new HashSet<RolesPages>();
        public ICollection<RolesOperations> RolesOperations { get; set; } = new HashSet<RolesOperations>();
        //public ICollection<RolesBaseAuthority> RolesBaseAuthority { get; set; } = new HashSet<RolesBaseAuthority>();
        public ICollection<RolesApis> RolesApis { get; set; } = new HashSet<RolesApis>();

        public string GetTitle() => Name;
        public string GetTypeName() => "role";
        public Roles Clone() => new Roles
        {
            Id = Guid.NewGuid(),
            Name = this.Name
        };
        public void SetTitle(string v)
        {
            this.Name = v;
        }
    }

    public class RolesTypes
    {
        [HideForEdit]
        [HideForDisplay]
        public Guid Id { get; set; }
        [Display(Name = "名稱", Order = 1)]
        public string Name { get; set; }
        [Display(Name = "描述", Order = 2)]
        public string Description { get; set; }
        [HideForEdit]
        [HideForDisplay]
        public string NormalizedName { get; set; }
        [HideForEdit]
        [HideForDisplay]
        public string ConcurrencyStamp { get; set; }
    }
}
