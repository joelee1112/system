using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Users
    {
        public Users()
        {
            Sessions = new HashSet<Sessions>();
            UsersClaims = new HashSet<UsersClaims>();
            UsersGroups = new HashSet<UsersGroups>();
            UsersLogins = new HashSet<UsersLogins>();
            UsersRoles = new HashSet<UsersRoles>();
            UsersTokens = new HashSet<UsersTokens>();
        }

        public string Uuid { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public short EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public short PhoneNumberConfirmed { get; set; }
        public short TwoFactorEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public short LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public short IsDelete { get; set; }

        public virtual ICollection<Sessions> Sessions { get; set; }
        public virtual ICollection<UsersClaims> UsersClaims { get; set; }
        public virtual ICollection<UsersGroups> UsersGroups { get; set; }
        public virtual ICollection<UsersLogins> UsersLogins { get; set; }
        public virtual ICollection<UsersRoles> UsersRoles { get; set; }
        public virtual ICollection<UsersTokens> UsersTokens { get; set; }
    }
}
