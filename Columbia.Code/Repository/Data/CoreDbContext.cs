using $safesolutionname$.Entity;
using Microsoft.EntityFrameworkCore;

namespace $safesolutionname$.Repository.Data
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {

        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Entity.Action> Actions { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<MenuOption> MenuOptions { get; set; } = null!;
        public virtual DbSet<Entity.Module> Modules { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity.Action>(entity =>
            {
                entity.HasIndex(e => e.ModuleId, "IX_Actions_ModuleId");

                entity.HasIndex(e => e.ParentActionId, "IX_Actions_ParentActionId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(64);

                entity.Property(e => e.CreationUser).HasMaxLength(64);

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.UpdateUser).HasMaxLength(64);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.ModuleId);

                entity.HasOne(d => d.ParentAction)
                    .WithMany(p => p.InverseParentAction)
                    .HasForeignKey(d => d.ParentActionId);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<MenuOption>(entity =>
            {
                entity.HasIndex(e => e.ActionId, "IX_MenuOptions_ActionId");

                entity.HasIndex(e => e.ParentMenuOptionId, "IX_MenuOptions_ParentMenuOptionId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(64);

                entity.Property(e => e.CreationUser).HasMaxLength(64);

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.MenuIcon).IsUnicode(false);

                entity.Property(e => e.MenuUri).IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.UpdateUser).HasMaxLength(64);

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.MenuOptions)
                    .HasForeignKey(d => d.ActionId);

                entity.HasOne(d => d.ParentMenuOption)
                    .WithMany(p => p.InverseParentMenuOption)
                    .HasForeignKey(d => d.ParentMenuOptionId);
            });

            modelBuilder.Entity<Entity.Module>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(64);

                entity.Property(e => e.CreationUser).HasMaxLength(64);

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.UpdateUser).HasMaxLength(64);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(e => e.ActionId, "IX_Permissions_ActionId");

                entity.HasIndex(e => e.RoleId, "IX_Permissions_RoleId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationUser).HasMaxLength(64);

                entity.Property(e => e.UpdateUser).HasMaxLength(64);

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.ActionId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RoleId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
