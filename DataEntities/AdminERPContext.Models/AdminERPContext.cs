using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataEntities.AdminERPContext.Models
{
    public partial class AdminERPContext : DbContext
    {
        public AdminERPContext()
        {
        }

        public AdminERPContext(DbContextOptions<AdminERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<AssetCategory> AssetCategory { get; set; }
        public virtual DbSet<AssetDetail> AssetDetail { get; set; }
        public virtual DbSet<AssetGatePass> AssetGatePass { get; set; }
        public virtual DbSet<AssetGatePassDetail> AssetGatePassDetail { get; set; }
        public virtual DbSet<AssetGatePassSenderDetail> AssetGatePassSenderDetail { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<GatePassStatus> GatePassStatus { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<QuantityUnit> QuantityUnit { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleFunction> RoleFunction { get; set; }
        public virtual DbSet<RoleMenu> RoleMenu { get; set; }
        public virtual DbSet<SecurityQuestion> SecurityQuestion { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCredential> UserCredential { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserSecurityAnswer> UserSecurityAnswer { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(local);Database=AdminERP;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetCategoryId).HasColumnName("AssetCategoryID");

                entity.Property(e => e.AssetDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AssetName)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.AssetTagId)
                    .IsRequired()
                    .HasColumnName("AssetTagID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AssetCategory)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.AssetCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asset_AssetCategory");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AssetCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asset_User");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.AssetModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asset_User1");
            });

            modelBuilder.Entity<AssetCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AssetCategoryCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetCategory_User");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.AssetCategoryModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetCategory_User1");
            });

            modelBuilder.Entity<AssetDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.BrandName).HasMaxLength(10);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModelNumber).HasMaxLength(10);

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.SerialNumber).HasMaxLength(10);

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.Property(e => e.WarrantyExpireDate).HasColumnType("date");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.AssetDetail)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_AssetDetail_Asset");
            });

            modelBuilder.Entity<AssetGatePass>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GatePassDate).HasColumnType("datetime");

                entity.Property(e => e.GatePassNo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GatePassStatusId).HasColumnName("GatePassStatusID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(800)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AssetGatePassCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetGatePass_User1");

                entity.HasOne(d => d.GatePassStatus)
                    .WithMany(p => p.AssetGatePass)
                    .HasForeignKey(d => d.GatePassStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetGatePass_GatePassStatus");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.AssetGatePassModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetGatePass_User2");

                entity.HasOne(d => d.ReceivedByNavigation)
                    .WithMany(p => p.AssetGatePassReceivedByNavigation)
                    .HasForeignKey(d => d.ReceivedBy)
                    .HasConstraintName("FK_AssetGatePass_User");
            });

            modelBuilder.Entity<AssetGatePassDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetGatePassId).HasColumnName("AssetGatePassID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.ReceivedQty).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ReceivedQtyUnitId).HasColumnName("ReceivedQtyUnitID");

                entity.Property(e => e.SendQty).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SendQtyUnitId).HasColumnName("SendQtyUnitID");

                entity.HasOne(d => d.AssetGatePass)
                    .WithMany(p => p.AssetGatePassDetail)
                    .HasForeignKey(d => d.AssetGatePassId)
                    .HasConstraintName("FK_AssetGatePassDetail_AssetGatePass");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetGatePassDetail)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AssetGatePassDetail_Asset");

                entity.HasOne(d => d.ReceivedQtyUnit)
                    .WithMany(p => p.AssetGatePassDetailReceivedQtyUnit)
                    .HasForeignKey(d => d.ReceivedQtyUnitId)
                    .HasConstraintName("FK_AssetGatePassDetail_QuantityUnit1");

                entity.HasOne(d => d.SendQtyUnit)
                    .WithMany(p => p.AssetGatePassDetailSendQtyUnit)
                    .HasForeignKey(d => d.SendQtyUnitId)
                    .HasConstraintName("FK_AssetGatePassDetail_QuantityUnit");
            });

            modelBuilder.Entity<AssetGatePassSenderDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AssetGatePassId).HasColumnName("AssetGatePassID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AssetGatePass)
                    .WithMany(p => p.AssetGatePassSenderDetail)
                    .HasForeignKey(d => d.AssetGatePassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetGatePassSenderDetail_AssetGatePass");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WebSiteUrl)
                    .HasColumnName("WebSiteURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CompanyCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_User");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CompanyModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_User1");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.DepartmentCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_User");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.DepartmentModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_User1");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FunctionCode)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FunctionDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FunctionName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GatePassStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GatePassStatus1)
                    .HasColumnName("GatePassStatus")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Controller).HasMaxLength(150);

                entity.Property(e => e.ControllerAs).HasMaxLength(50);

                entity.Property(e => e.MenuLink).HasMaxLength(255);

                entity.Property(e => e.MenuTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tag).HasMaxLength(20);

                entity.Property(e => e.TemplateUrl).HasMaxLength(150);
            });

            modelBuilder.Entity<QuantityUnit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RoleDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RoleCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_User1");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.RoleModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_User2");
            });

            modelBuilder.Entity<RoleFunction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FunctionId).HasColumnName("FunctionID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.RoleFunction)
                    .HasForeignKey(d => d.FunctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleFunction_Function");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleFunction)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleFunction_Role");
            });

            modelBuilder.Entity<RoleMenu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.RoleMenu)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMenu_Menu");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleMenu)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMenu_Roles");
            });

            modelBuilder.Entity<SecurityQuestion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordKey)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCredential)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCredential_User");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User1");
            });

            modelBuilder.Entity<UserSecurityAnswer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestionId).HasColumnName("SecurityQuestionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.SecurityQuestion)
                    .WithMany(p => p.UserSecurityAnswer)
                    .HasForeignKey(d => d.SecurityQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSecurityAnswer_SecurityQuestion");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSecurityAnswer)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSecurityAnswer_User");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
