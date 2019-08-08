using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Datas
{
    public partial class ParkingContext : DbContext
    {
        public ParkingContext()
        {
        }

        public ParkingContext(DbContextOptions<ParkingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apis> Apis { get; set; }
        public virtual DbSet<BaseAuthority> BaseAuthority { get; set; }
        public virtual DbSet<BaseCarParkType> BaseCarParkType { get; set; }
        public virtual DbSet<BaseCity> BaseCity { get; set; }
        public virtual DbSet<BaseEntranceType> BaseEntranceType { get; set; }
        public virtual DbSet<BaseOperationType> BaseOperationType { get; set; }
        public virtual DbSet<BaseParkingGuideType> BaseParkingGuideType { get; set; }
        public virtual DbSet<BaseParkingSiteType> BaseParkingSiteType { get; set; }
        public virtual DbSet<BaseParkingType> BaseParkingType { get; set; }
        public virtual DbSet<BaseSupervisionType> BaseSupervisionType { get; set; }
        public virtual DbSet<BaseTown> BaseTown { get; set; }
        public virtual DbSet<Contents> Contents { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<FormsValues> FormsValues { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<GroupsRoles> GroupsRoles { get; set; }
        public virtual DbSet<Layouts> Layouts { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<OffStreetActivityCarPark> OffStreetActivityCarPark { get; set; }
        public virtual DbSet<OffStreetAirportCarPark> OffStreetAirportCarPark { get; set; }
        public virtual DbSet<OffStreetCarParkBaseParkingSiteType> OffStreetCarParkBaseParkingSiteType { get; set; }
        public virtual DbSet<OffStreetCarParkBaseParkingType> OffStreetCarParkBaseParkingType { get; set; }
        public virtual DbSet<OffStreetFreewayCarPark> OffStreetFreewayCarPark { get; set; }
        public virtual DbSet<OffStreetImageUrl> OffStreetImageUrl { get; set; }
        public virtual DbSet<OffStreetParkingArea> OffStreetParkingArea { get; set; }
        public virtual DbSet<OffStreetParkingAreaBaseParkingType> OffStreetParkingAreaBaseParkingType { get; set; }
        public virtual DbSet<OffStreetParkingEntranceExit> OffStreetParkingEntranceExit { get; set; }
        public virtual DbSet<OffStreetRailStationCarPark> OffStreetRailStationCarPark { get; set; }
        public virtual DbSet<OffStreetScenicSpotCarPark> OffStreetScenicSpotCarPark { get; set; }
        public virtual DbSet<OnStreetImageUrl> OnStreetImageUrl { get; set; }
        public virtual DbSet<OnStreetParkingSegment> OnStreetParkingSegment { get; set; }
        public virtual DbSet<OnStreetParkingSegmentLink> OnStreetParkingSegmentLink { get; set; }
        public virtual DbSet<OnStreetParkingSegmentRoad> OnStreetParkingSegmentRoad { get; set; }
        public virtual DbSet<Operations> Operations { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<Picklists> Picklists { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesApis> RolesApis { get; set; }
        public virtual DbSet<RolesBaseAuthority> RolesBaseAuthority { get; set; }
        public virtual DbSet<RolesClaims> RolesClaims { get; set; }
        public virtual DbSet<RolesMenus> RolesMenus { get; set; }
        public virtual DbSet<RolesOperations> RolesOperations { get; set; }
        public virtual DbSet<RolesPages> RolesPages { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<SessionsRoles> SessionsRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersClaims> UsersClaims { get; set; }
        public virtual DbSet<UsersGroups> UsersGroups { get; set; }
        public virtual DbSet<UsersLogins> UsersLogins { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }
        public virtual DbSet<UsersTokens> UsersTokens { get; set; }
        public virtual DbSet<Version> Version { get; set; }
        public virtual DbSet<VersionDetail> VersionDetail { get; set; }

        // Unable to generate entity type for table 'Parking.OffStreetCarPark'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=192.168.99.250;Database=Parking;User Id=PTX-DB-User;Password=rul wj/ 1j4ej/ ej/4mp4gj !@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Apis>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("Apis", "Parking");

                entity.HasIndex(e => e.OperationId);

                entity.HasIndex(e => e.PageId);

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.OperationId).HasColumnType("char(36)");

                entity.Property(e => e.PageId).HasColumnType("char(36)");

                entity.Property(e => e.Sequence).HasColumnType("int(11)");

                entity.Property(e => e.Url)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Apis)
                    .HasForeignKey(d => d.OperationId);

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Apis)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<BaseAuthority>(entity =>
            {
                entity.HasKey(e => e.PkBaseAuthority);

                entity.ToTable("BaseAuthority", "Parking");

                entity.Property(e => e.PkBaseAuthority)
                    .HasColumnName("PK_BaseAuthority")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorityCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogoUrl)
                    .HasColumnName("LogoURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameEnUs)
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Oid)
                    .HasColumnName("OID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WeUrl)
                    .HasColumnName("WeURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseCarParkType>(entity =>
            {
                entity.HasKey(e => e.PkBaseCarParkType);

                entity.ToTable("BaseCarParkType", "Parking");

                entity.Property(e => e.PkBaseCarParkType)
                    .HasColumnName("PK_BaseCarParkType")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CarParkTypeId)
                    .HasColumnName("CarParkTypeID")
                    .HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.NameEnUs)
                    .IsRequired()
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseCity>(entity =>
            {
                entity.HasKey(e => e.PkBaseCity);

                entity.ToTable("BaseCity", "Parking");

                entity.HasIndex(e => e.EnumId)
                    .HasName("EnumID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PkBaseCity)
                    .HasColumnName("PK_BaseCity")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityCode)
                    .IsRequired()
                    .HasColumnType("char(3)");

                entity.Property(e => e.CountyId)
                    .IsRequired()
                    .HasColumnName("CountyID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EnumId)
                    .HasColumnName("EnumID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NameEnUs)
                    .IsRequired()
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseEntranceType>(entity =>
            {
                entity.HasKey(e => e.PkBaseEntranceType);

                entity.ToTable("BaseEntranceType", "Parking");

                entity.Property(e => e.PkBaseEntranceType)
                    .HasColumnName("PK_BaseEntranceType")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.EntranceTypeId)
                    .HasColumnName("EntranceTypeID")
                    .HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.NameEnUs)
                    .IsRequired()
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseOperationType>(entity =>
            {
                entity.HasKey(e => e.PkBaseOperationType);

                entity.ToTable("BaseOperationType", "Parking");

                entity.Property(e => e.PkBaseOperationType)
                    .HasColumnName("PK_BaseOperationType")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameEnUs)
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OperationTypeId)
                    .HasColumnName("OperationTypeID")
                    .HasColumnType("tinyint(1) unsigned");
            });

            modelBuilder.Entity<BaseParkingGuideType>(entity =>
            {
                entity.HasKey(e => e.PkBaseParkingGuideType);

                entity.ToTable("BaseParkingGuideType", "Parking");

                entity.Property(e => e.PkBaseParkingGuideType)
                    .HasColumnName("PK_BaseParkingGuideType")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameEnUs)
                    .IsRequired()
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParkingGuideTypeId)
                    .HasColumnName("ParkingGuideTypeID")
                    .HasColumnType("tinyint(1) unsigned");
            });

            modelBuilder.Entity<BaseParkingSiteType>(entity =>
            {
                entity.HasKey(e => e.PkBaseParkingSiteType);

                entity.ToTable("BaseParkingSiteType", "Parking");

                entity.Property(e => e.PkBaseParkingSiteType)
                    .HasColumnName("PK_BaseParkingSiteType")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameEnUs)
                    .IsRequired()
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParkingSiteTypeId)
                    .HasColumnName("ParkingSiteTypeID")
                    .HasColumnType("tinyint(1) unsigned");
            });

            modelBuilder.Entity<BaseParkingType>(entity =>
            {
                entity.HasKey(e => e.PkBaseParkingType);

                entity.ToTable("BaseParkingType", "Parking");

                entity.Property(e => e.PkBaseParkingType)
                    .HasColumnName("PK_BaseParkingType")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameEnUs)
                    .IsRequired()
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParkingTypeId)
                    .HasColumnName("ParkingTypeID")
                    .HasColumnType("tinyint(1) unsigned");
            });

            modelBuilder.Entity<BaseSupervisionType>(entity =>
            {
                entity.HasKey(e => e.PkBaseSupervisionType);

                entity.ToTable("BaseSupervisionType", "Parking");

                entity.Property(e => e.PkBaseSupervisionType)
                    .HasColumnName("PK_BaseSupervisionType")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameEnUs)
                    .IsRequired()
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupervisionTypeId)
                    .HasColumnName("SupervisionTypeID")
                    .HasColumnType("tinyint(1) unsigned");
            });

            modelBuilder.Entity<BaseTown>(entity =>
            {
                entity.HasKey(e => e.PkBaseTown);

                entity.ToTable("BaseTown", "Parking");

                entity.Property(e => e.PkBaseTown)
                    .HasColumnName("PK_BaseTown")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseCity)
                    .IsRequired()
                    .HasColumnName("FK_BaseCity")
                    .HasColumnType("char(36)");

                entity.Property(e => e.NameEnUs)
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TownId)
                    .IsRequired()
                    .HasColumnName("TownID")
                    .HasColumnType("char(7)");
            });

            modelBuilder.Entity<Contents>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("Contents", "Parking");

                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.BeginTime).HasColumnType("datetime(6)");

                entity.Property(e => e.ContentType).HasColumnType("tinyint(4)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime(6)");

                entity.Property(e => e.FileUrl)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Html)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Identity)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.IsAgent).HasColumnType("bit(1)");

                entity.Property(e => e.IsEnable).HasColumnType("bit(1)");

                entity.Property(e => e.IsFooter).HasColumnType("bit(1)");

                entity.Property(e => e.IsTop).HasColumnType("bit(1)");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime(6)");

                entity.Property(e => e.ParentId).HasColumnType("char(36)");

                entity.Property(e => e.PostTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Sequence).HasColumnType("int(11)");

                entity.Property(e => e.SortValue).HasColumnType("int(11)");

                entity.Property(e => e.Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbUrl)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ViewName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<Forms>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("Forms", "Parking");

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.IsDelete).HasColumnType("bit(1)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("longtext");
            });

            modelBuilder.Entity<FormsValues>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("FormsValues", "Parking");

                entity.HasIndex(e => e.LayoutId);

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.IsDelete).HasColumnType("bit(1)");

                entity.Property(e => e.LayoutId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.Value)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Layout)
                    .WithMany(p => p.FormsValues)
                    .HasForeignKey(d => d.LayoutId);
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("Groups", "Parking");

                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnType("char(36)");

                entity.Property(e => e.Sequence).HasColumnType("int(11)");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<GroupsRoles>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.RoleId });

                entity.ToTable("GroupsRoles", "Parking");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.GroupId).HasColumnType("char(36)");

                entity.Property(e => e.RoleId).HasColumnType("char(36)");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupsRoles)
                    .HasForeignKey(d => d.GroupId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.GroupsRoles)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Layouts>(entity =>
            {
                entity.ToTable("Layouts", "Parking");

                entity.Property(e => e.Id)
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.IsDelete).HasColumnType("bit(1)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("longtext");
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("Menus", "Parking");

                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Icon)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnType("char(36)");

                entity.Property(e => e.Sequence).HasColumnType("int(11)");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<OffStreetActivityCarPark>(entity =>
            {
                entity.HasKey(e => e.PkOffStreetActivityCarPark);

                entity.ToTable("OffStreetActivityCarPark", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.ActivityId })
                    .HasName("Version_AcID_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOffStreetCarPark })
                    .HasName("Version_FK_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.PkOffStreetActivityCarPark })
                    .HasName("Version_PK_Index");

                entity.Property(e => e.PkOffStreetActivityCarPark)
                    .HasColumnName("PK_OffStreetActivityCarPark")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityId)
                    .IsRequired()
                    .HasColumnName("ActivityID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityNameEnUs)
                    .IsRequired()
                    .HasColumnName("ActivityNameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityNameZhTw)
                    .IsRequired()
                    .HasColumnName("ActivityNameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOffStreetCarPark)
                    .IsRequired()
                    .HasColumnName("FK_OffStreetCarPark")
                    .HasColumnType("char(36)");

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OffStreetAirportCarPark>(entity =>
            {
                entity.HasKey(e => e.PkOffStreetAirportCarPark);

                entity.ToTable("OffStreetAirportCarPark", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.AirportId })
                    .HasName("Version_AirID_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOffStreetCarPark })
                    .HasName("Version_FK_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.PkOffStreetAirportCarPark })
                    .HasName("Version_PK_Index");

                entity.Property(e => e.PkOffStreetAirportCarPark)
                    .HasColumnName("PK_OffStreetAirportCarPark")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AirportId)
                    .IsRequired()
                    .HasColumnName("AirportID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AirportNameEnUs)
                    .IsRequired()
                    .HasColumnName("AirportNameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AirportNameZhTw)
                    .IsRequired()
                    .HasColumnName("AirportNameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOffStreetCarPark)
                    .IsRequired()
                    .HasColumnName("FK_OffStreetCarPark")
                    .HasColumnType("char(36)");

                entity.Property(e => e.Terminal)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OffStreetCarParkBaseParkingSiteType>(entity =>
            {
                entity.HasKey(e => e.PkOffStreetCarParkBaseParkingSiteType);

                entity.ToTable("OffStreetCarPark_BaseParkingSiteType", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOffStreetCarPark })
                    .HasName("Version_Index");

                entity.Property(e => e.PkOffStreetCarParkBaseParkingSiteType)
                    .HasColumnName("PK_OffStreetCarPark_BaseParkingSiteType")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkBaseParkingSiteType)
                    .IsRequired()
                    .HasColumnName("FK_BaseParkingSiteType")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOffStreetCarPark)
                    .IsRequired()
                    .HasColumnName("FK_OffStreetCarPark")
                    .HasColumnType("char(36)");

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OffStreetCarParkBaseParkingType>(entity =>
            {
                entity.HasKey(e => e.PkOffStreetCarParkBaseParkingType);

                entity.ToTable("OffStreetCarPark_BaseParkingType", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOffStreetCarPark })
                    .HasName("Version_Index");

                entity.Property(e => e.PkOffStreetCarParkBaseParkingType)
                    .HasColumnName("PK_OffStreetCarPark_BaseParkingType")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkBaseParkingType)
                    .IsRequired()
                    .HasColumnName("FK_BaseParkingType")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOffStreetCarPark)
                    .IsRequired()
                    .HasColumnName("FK_OffStreetCarPark")
                    .HasColumnType("char(36)");

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OffStreetFreewayCarPark>(entity =>
            {
                entity.HasKey(e => e.PkOffStreetFreewayCarPark);

                entity.ToTable("OffStreetFreewayCarPark", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOffStreetCarPark })
                    .HasName("Version_FK_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.ServiceAreaId })
                    .HasName("Version_ID_Index");

                entity.Property(e => e.PkOffStreetFreewayCarPark)
                    .HasColumnName("PK_OffStreetFreewayCarPark")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOffStreetCarPark)
                    .IsRequired()
                    .HasColumnName("FK_OffStreetCarPark")
                    .HasColumnType("char(36)");

                entity.Property(e => e.ServicAreaNameEnUs)
                    .IsRequired()
                    .HasColumnName("ServicAreaNameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceAreaId)
                    .IsRequired()
                    .HasColumnName("ServiceAreaID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceAreaNameZhTw)
                    .IsRequired()
                    .HasColumnName("ServiceAreaNameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OffStreetImageUrl>(entity =>
            {
                entity.HasKey(e => e.PkOffStreetImageUrl);

                entity.ToTable("OffStreetImageURL", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOffStreetCarPark })
                    .HasName("Version_Index");

                entity.Property(e => e.PkOffStreetImageUrl)
                    .HasColumnName("PK_OffStreetImageURL")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOffStreetCarPark)
                    .IsRequired()
                    .HasColumnName("FK_OffStreetCarPark")
                    .HasColumnType("char(36)");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("ImageURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OffStreetParkingArea>(entity =>
            {
                entity.HasKey(e => e.PkOffStreetParkingArea);

                entity.ToTable("OffStreetParkingArea", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOffStreetCarPark })
                    .HasName("Version_FK_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.ParkingAreaId })
                    .HasName("Version_ID_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.PkOffStreetParkingArea })
                    .HasName("Version_PK_Index");

                entity.Property(e => e.PkOffStreetParkingArea)
                    .HasColumnName("PK_OffStreetParkingArea")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOffStreetCarPark)
                    .IsRequired()
                    .HasColumnName("FK_OffStreetCarPark")
                    .HasColumnType("char(36)");

                entity.Property(e => e.Geometry).HasColumnType("mediumtext");

                entity.Property(e => e.NameEnUs)
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParkingAreaId)
                    .IsRequired()
                    .HasColumnName("ParkingAreaID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OffStreetParkingAreaBaseParkingType>(entity =>
            {
                entity.HasKey(e => e.PkOffStreetParkingAreaBaseParkingType);

                entity.ToTable("OffStreetParkingArea_BaseParkingType", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOffStreetParkingArea })
                    .HasName("Version_Index");

                entity.Property(e => e.PkOffStreetParkingAreaBaseParkingType)
                    .HasColumnName("PK_OffStreetParkingArea_BaseParkingType")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkBaseParkingType)
                    .IsRequired()
                    .HasColumnName("FK_BaseParkingType")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOffStreetParkingArea)
                    .IsRequired()
                    .HasColumnName("FK_OffStreetParkingArea")
                    .HasColumnType("char(36)");

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OffStreetParkingEntranceExit>(entity =>
            {
                entity.HasKey(e => e.PkOffStreetParkingEntranceExit);

                entity.ToTable("OffStreetParkingEntranceExit", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOffStreetCarPark })
                    .HasName("Version_Index");

                entity.Property(e => e.PkOffStreetParkingEntranceExit)
                    .HasColumnName("PK_OffStreetParkingEntranceExit")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bearing)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CrossRoadName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntranceExitType).HasColumnType("smallint(1)");

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkBaseEntranceType)
                    .IsRequired()
                    .HasColumnName("FK_BaseEntranceType")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOffStreetCarPark)
                    .IsRequired()
                    .HasColumnName("FK_OffStreetCarPark")
                    .HasColumnType("char(36)");

                entity.Property(e => e.Latitude).HasColumnType("float(7,5)");

                entity.Property(e => e.LinkId)
                    .HasColumnName("LinkID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude).HasColumnType("float(8,5)");

                entity.Property(e => e.NameEnUs)
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoadId)
                    .HasColumnName("RoadID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RoadName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OffStreetRailStationCarPark>(entity =>
            {
                entity.HasKey(e => e.PkOffStreetRailStationCarPark);

                entity.ToTable("OffStreetRailStationCarPark", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOffStreetCarPark })
                    .HasName("Version_FK_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.StationId })
                    .HasName("Version_StaID_Index");

                entity.Property(e => e.PkOffStreetRailStationCarPark)
                    .HasColumnName("PK_OffStreetRailStationCarPark")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOffStreetCarPark)
                    .IsRequired()
                    .HasColumnName("FK_OffStreetCarPark")
                    .HasColumnType("char(36)");

                entity.Property(e => e.StationId)
                    .IsRequired()
                    .HasColumnName("StationID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.StationNameEnUs)
                    .HasColumnName("StationNameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StationNameZhTw)
                    .IsRequired()
                    .HasColumnName("StationNameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OffStreetScenicSpotCarPark>(entity =>
            {
                entity.HasKey(e => e.PkOffStreetScenicSpotCarPark);

                entity.ToTable("OffStreetScenicSpotCarPark", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOffStreetCarPark })
                    .HasName("Version_FK_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.ScenicSpotId })
                    .HasName("Version_SceID_Index");

                entity.Property(e => e.PkOffStreetScenicSpotCarPark)
                    .HasColumnName("PK_OffStreetScenicSpotCarPark")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOffStreetCarPark)
                    .IsRequired()
                    .HasColumnName("FK_OffStreetCarPark")
                    .HasColumnType("char(36)");

                entity.Property(e => e.ScenicSpotId)
                    .IsRequired()
                    .HasColumnName("ScenicSpotID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ScenicSpotNameEnUs)
                    .IsRequired()
                    .HasColumnName("ScenicSpotNameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ScenicSpotNameZhTw)
                    .IsRequired()
                    .HasColumnName("ScenicSpotNameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OnStreetImageUrl>(entity =>
            {
                entity.HasKey(e => e.PkOnStreetImageUrl);

                entity.ToTable("OnStreetImageURL", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOnStreetParkingSegment })
                    .HasName("Version_Index");

                entity.Property(e => e.PkOnStreetImageUrl)
                    .HasColumnName("PK_OnStreetImageURL")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOnStreetParkingSegment)
                    .IsRequired()
                    .HasColumnName("FK_OnStreetParkingSegment")
                    .HasColumnType("char(36)");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("ImageURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OnStreetParkingSegment>(entity =>
            {
                entity.HasKey(e => e.PkOnStreetParkingSegment);

                entity.ToTable("OnStreetParkingSegment", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.ParkingSegmentId })
                    .HasName("Version_ID_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.PkOnStreetParkingSegment })
                    .HasName("Version_PK_Index");

                entity.Property(e => e.PkOnStreetParkingSegment)
                    .HasColumnName("PK_OnStreetParkingSegment")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EndRoadSection)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FareDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkBaseCity)
                    .IsRequired()
                    .HasColumnName("FK_BaseCity")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkBaseTown)
                    .IsRequired()
                    .HasColumnName("FK_BaseTown")
                    .HasColumnType("char(36)");

                entity.Property(e => e.Geometry).HasColumnType("mediumtext");

                entity.Property(e => e.LandMark)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("float(7,5)");

                entity.Property(e => e.Longitude).HasColumnType("float(8,5)");

                entity.Property(e => e.NameEnUs)
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParkingSegmentId)
                    .IsRequired()
                    .HasColumnName("ParkingSegmentID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialOfferDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StartRoadSection)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OnStreetParkingSegmentLink>(entity =>
            {
                entity.HasKey(e => e.PkOnStreetParkingSegmentLink);

                entity.ToTable("OnStreetParkingSegment_Link", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOnStreetParkingSegment })
                    .HasName("Version_Index");

                entity.Property(e => e.PkOnStreetParkingSegmentLink)
                    .HasColumnName("PK_OnStreetParkingSegment_Link")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOnStreetParkingSegment)
                    .IsRequired()
                    .HasColumnName("FK_OnStreetParkingSegment")
                    .HasColumnType("char(36)");

                entity.Property(e => e.LinkId)
                    .IsRequired()
                    .HasColumnName("LinkID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OnStreetParkingSegmentRoad>(entity =>
            {
                entity.HasKey(e => e.PkOnStreetParkingSegmentRoad);

                entity.ToTable("OnStreetParkingSegment_Road", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.FkOnStreetParkingSegment })
                    .HasName("Version_Index");

                entity.Property(e => e.PkOnStreetParkingSegmentRoad)
                    .HasColumnName("PK_OnStreetParkingSegment_Road")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.FkOnStreetParkingSegment)
                    .IsRequired()
                    .HasColumnName("FK_OnStreetParkingSegment")
                    .HasColumnType("char(36)");

                entity.Property(e => e.RoadId)
                    .IsRequired()
                    .HasColumnName("RoadID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Operations>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("Operations", "Parking");

                entity.HasIndex(e => e.PageId);

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PageId).HasColumnType("char(36)");

                entity.Property(e => e.Sequence).HasColumnType("int(11)");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.HasKey(e => e.PkOperator);

                entity.ToTable("Operator", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version, e.PkOperator })
                    .HasName("Version_Index");

                entity.Property(e => e.PkOperator)
                    .HasColumnName("PK_Operator")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ban)
                    .IsRequired()
                    .HasColumnName("BAN")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.LogoUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameEnUs)
                    .HasColumnName("NameEn_us")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameZhTw)
                    .IsRequired()
                    .HasColumnName("NameZh_tw")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OperatorId)
                    .IsRequired()
                    .HasColumnName("OperatorID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TsAndCsUrl)
                    .HasColumnName("TsAndCsURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnType("int(11)");

                entity.Property(e => e.WebUrl)
                    .HasColumnName("WebURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pages>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("Pages", "Parking");

                entity.HasIndex(e => e.MenuId);

                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Icon)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.MenuId).HasColumnType("char(36)");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnType("char(36)");

                entity.Property(e => e.Sequence).HasColumnType("int(11)");

                entity.Property(e => e.Url)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.MenuId);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<Picklists>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("Picklists", "Parking");

                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.IsActive).HasColumnType("bit(1)");

                entity.Property(e => e.IsDelete).HasColumnType("bit(1)");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime(6)");

                entity.Property(e => e.ParentId).HasColumnType("char(36)");

                entity.Property(e => e.Sequence).HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("Roles", "Parking");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConcurrencyStamp)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnType("bit(1)");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnType("char(36)");

                entity.Property(e => e.Sequence).HasColumnType("int(11)");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<RolesApis>(entity =>
            {
                entity.HasKey(e => new { e.ApiId, e.RoleId });

                entity.ToTable("RolesApis", "Parking");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.ApiId).HasColumnType("char(36)");

                entity.Property(e => e.RoleId).HasColumnType("char(36)");

                entity.HasOne(d => d.Api)
                    .WithMany(p => p.RolesApis)
                    .HasForeignKey(d => d.ApiId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesApis)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<RolesBaseAuthority>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.FkBaseAuthority });

                entity.ToTable("RolesBaseAuthority", "Parking");

                entity.Property(e => e.RoleId).HasColumnType("char(36)");

                entity.Property(e => e.FkBaseAuthority)
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");
            });

            modelBuilder.Entity<RolesClaims>(entity =>
            {
                entity.ToTable("RolesClaims", "Parking");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ClaimValue)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<RolesMenus>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.RoleId });

                entity.ToTable("RolesMenus", "Parking");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.MenuId).HasColumnType("char(36)");

                entity.Property(e => e.RoleId).HasColumnType("char(36)");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.RolesMenus)
                    .HasForeignKey(d => d.MenuId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesMenus)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<RolesOperations>(entity =>
            {
                entity.HasKey(e => new { e.OperationId, e.RoleId });

                entity.ToTable("RolesOperations", "Parking");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.OperationId).HasColumnType("char(36)");

                entity.Property(e => e.RoleId).HasColumnType("char(36)");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.RolesOperations)
                    .HasForeignKey(d => d.OperationId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesOperations)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<RolesPages>(entity =>
            {
                entity.HasKey(e => new { e.PageId, e.RoleId });

                entity.ToTable("RolesPages", "Parking");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.PageId).HasColumnType("char(36)");

                entity.Property(e => e.RoleId).HasColumnType("char(36)");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.RolesPages)
                    .HasForeignKey(d => d.PageId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesPages)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("Sessions", "Parking");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.ExpireTime).HasColumnType("datetime(6)");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<SessionsRoles>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.SessionId });

                entity.ToTable("SessionsRoles", "Parking");

                entity.HasIndex(e => e.SessionId);

                entity.Property(e => e.RoleId).HasColumnType("char(36)");

                entity.Property(e => e.SessionId).HasColumnType("char(36)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SessionsRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionsRoles)
                    .HasForeignKey(d => d.SessionId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("Users", "Parking");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.IsDelete).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnd).HasColumnType("datetime(6)");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.PictureUrl)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityStamp)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersClaims>(entity =>
            {
                entity.ToTable("UsersClaims", "Parking");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ClaimValue)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UsersGroups>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.UserId });

                entity.ToTable("UsersGroups", "Parking");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.GroupId).HasColumnType("char(36)");

                entity.Property(e => e.UserId).HasColumnType("char(36)");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.UsersGroups)
                    .HasForeignKey(d => d.GroupId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersGroups)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UsersLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("UsersLogins", "Parking");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderKey)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderDisplayName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UsersRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("UsersRoles", "Parking");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.UserId).HasColumnType("char(36)");

                entity.Property(e => e.RoleId).HasColumnType("char(36)");

                entity.Property(e => e.Reason)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("tinyint(4)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UsersTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("UsersTokens", "Parking");

                entity.Property(e => e.UserId).HasColumnType("char(36)");

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.HasKey(e => e.PkVersion);

                entity.ToTable("Version", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.ReleasedVersion })
                    .HasName("ReleasedVersion_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version1 })
                    .HasName("Version_Index");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.VersionTime })
                    .HasName("Time_Index");

                entity.Property(e => e.PkVersion)
                    .HasColumnName("PK_Version")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.IsFinish).HasColumnType("bit(1)");

                entity.Property(e => e.ReleasedVersion).HasColumnType("int(11)");

                entity.Property(e => e.SourceDataHash)
                    .IsRequired()
                    .HasColumnType("char(32)");

                entity.Property(e => e.Version1)
                    .HasColumnName("Version")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<VersionDetail>(entity =>
            {
                entity.HasKey(e => e.PkVersionDetail);

                entity.ToTable("VersionDetail", "Parking");

                entity.HasIndex(e => new { e.FkBaseAuthority, e.Version })
                    .HasName("Version_Index");

                entity.Property(e => e.PkVersionDetail)
                    .HasColumnName("PK_VersionDetail")
                    .HasColumnType("char(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkBaseAuthority)
                    .IsRequired()
                    .HasColumnName("FK_BaseAuthority")
                    .HasColumnType("char(36)");

                entity.Property(e => e.SrcDataTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SrcUpdateInterval).HasColumnType("int(11)");

                entity.Property(e => e.Version).HasColumnType("int(11)");
            });
        }
    }
}
