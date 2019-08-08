using Data.Rbac.Bindings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Rbac
{
    [ModelMetadataType(typeof(UsersTypes))]
    public class Users : IdentityUser<Guid>
    {
        [Display(Name = "名稱", Prompt = "請輸入名稱", Order = 2)]
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間", Order = 5)]
        [DisplayFormat(DataFormatString = Setting.ymdhms)]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? ModifyTime { get; set; }
        [HideForDisplay]
        public bool IsDelete { get; set; }

        public ICollection<UsersGroups> UsersGroups { get; set; } = new HashSet<UsersGroups>();
        public ICollection<UsersRoles> UsersRoles { get; set; } = new HashSet<UsersRoles>();
        public ICollection<Sessions> Sessions { get; set; }

        public Users()
        {
            Id = Guid.NewGuid();
        }
    }
    class UsersTypes
    {
        [Required]
        [Display(Name = "帳號", Prompt = "請輸入帳號", Order = 1)]
        public string UserName { get; set; }
        [HideForDisplay]
        public virtual int AccessFailedCount { get; set; }
        [EmailAddress]
        [Display(Order = 3, Prompt = "請輸入Email")]
        public virtual string Email { get; set; }
        [Display(Name = "是否啟用")]
        public virtual bool EmailConfirmed { get; set; }
        [HideForEdit]
        [HideForDisplay]
        public virtual Guid Id { get; set; }
        [HideForDisplay]
        public virtual bool LockoutEnabled { get; set; }
        [HideForDisplay]
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        [HideForDisplay]
        public virtual string PasswordHash { get; set; }
        [Phone]
        [Display(Name = "電話", Prompt = "請輸入電話", Order = 4)]
        public virtual string PhoneNumber { get; set; }
        [HideForDisplay]
        public virtual bool PhoneNumberConfirmed { get; set; }
        [HideForDisplay]
        public virtual string SecurityStamp { get; set; }
        [HideForDisplay]
        public virtual bool TwoFactorEnabled { get; set; }
        [HideForDisplay]
        public virtual string NormalizedUserName { get; set; }
        [HideForDisplay]
        public virtual string NormalizedEmail { get; set; }
        [HideForDisplay]
        public virtual string ConcurrencyStamp { get; set; }
        [HideForDisplay]
        public virtual DateTimeOffset? LockoutEnd { get; set; }
    }
}