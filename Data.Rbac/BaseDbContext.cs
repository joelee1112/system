using Data.MySql.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.Rbac
{
    public class BaseDbContext : IdentityDbContext<Users, Roles, Guid, IdentityUserClaim<Guid>, UsersRoles, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DbSet<Menus> Menus { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Contents> Contents { get; set; }
        public DbSet<Forms> Forms { get; set; }
        public DbSet<FormsValues> FormsValues { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<Operations> Operations { get; set; }
        public DbSet<Apis> Apis { get; set; }
        public DbSet<Layouts> Layouts { get; set; }
        public DbSet<Picklists> Picklists { get; set; }
        public DbSet<RolesMenus> RolesMenus { get; set; }
        public DbSet<RolesPages> RolesPages { get; set; }
        public DbSet<RolesOperations> RolesOperations { get; set; }
        public DbSet<RolesApis> RolesApis { get; set; }
        public DbSet<UsersGroups> UsersGroups { get; set; }
        public virtual DbSet<Version> Version { get; set; }

        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }

        public BaseDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseMySql("Server=192.168.99.250;Database=Parking;User Id=PTX-DB-User;Password=rul wj/ 1j4ej/ ej/4mp4gj !@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UsersRoles>().ToTable("UsersRoles");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UsersLogins");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UsersClaims");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RolesClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UsersTokens");

            builder.Entity<Users>().Property(a => a.Id).HasColumnName("UUID");
            builder.Entity<Roles>().Property(a => a.Id).HasColumnName("UUID");
            builder.Entity<Users>().ToTable("Users").HasMany(a => a.UsersRoles).WithOne().HasForeignKey(a => a.UserId);
            builder.Entity<Roles>().ToTable("Roles").HasMany(a => a.Users).WithOne().HasForeignKey(a => a.RoleId);

            builder.Entity<RolesMenus>().HasOne(a => a.Role).WithMany(a => a.RolesMenus).HasForeignKey(a => a.RoleId);
            builder.Entity<RolesMenus>().HasOne(a => a.Menu).WithMany(a => a.RolesMenus).HasForeignKey(a => a.MenuId);
            builder.Entity<RolesMenus>().HasKey(a => new { a.MenuId, a.RoleId });
            builder.Entity<RolesPages>().HasKey(a => new { a.PageId, a.RoleId });
            builder.Entity<RolesOperations>().HasKey(a => new { a.OperationId, a.RoleId });
            builder.Entity<RolesApis>().HasKey(a => new { a.ApiId, a.RoleId });
            builder.Entity<UsersGroups>().HasKey(a => new { a.GroupId, a.UserId });
            builder.Entity<GroupsRoles>().HasKey(a => new { a.GroupId, a.RoleId });
            builder.Entity<SessionsRoles>().HasKey(a => new { a.RoleId, a.SessionId });
          

            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null)
                    property.SetMaxLength(256);
            }

            builder.SetAnnotation();
            builder.InitialData();
        }
    }
}
