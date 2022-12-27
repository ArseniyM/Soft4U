using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Soft4U.DB;

public partial class Soft4UDbContext : DbContext
{
    public Soft4UDbContext()
    {
    }

    public Soft4UDbContext(DbContextOptions<Soft4UDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationsUser> ApplicationsUsers { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProgram> UserPrograms { get; set; }
    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source = ..\\..\\..\\DB\\Soft4U_DB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationsUser>(entity =>
        {
            entity.ToTable("ApplicationsUser");

            entity.HasIndex(e => e.Id, "IX_ApplicationsUser_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Idprogramm).HasColumnName("idprogramm");
            entity.Property(e => e.Idtype).HasColumnName("idtype");
            entity.Property(e => e.Iduser).HasColumnName("iduser");

            entity.HasOne(d => d.IdprogrammNavigation).WithMany(p => p.ApplicationsUsers)
                .HasForeignKey(d => d.Idprogramm)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdstatusNavigation).WithMany(p => p.ApplicationsUsers)
                .HasForeignKey(d => d.Idstatus)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdtypeNavigation).WithMany(p => p.ApplicationsUsers)
                .HasForeignKey(d => d.Idtype)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.ApplicationsUsers)
                .HasForeignKey(d => d.Iduser)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.ToTable("programs");

            entity.HasIndex(e => e.Id, "IX_programs_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Discription).HasColumnName("discription");
            entity.Property(e => e.License).HasColumnName("license");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.HasIndex(e => e.Id, "IX_Role_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Rolename).HasColumnName("rolename");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("Type");

            entity.HasIndex(e => e.Id, "IX_Type_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.Id, "IX_User_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Foto).HasColumnName("foto");
            entity.Property(e => e.Middlename).HasColumnName("middlename");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Surname).HasColumnName("surname");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.HasIndex(e => e.Id, "IX_Status_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName).HasColumnName("statusName");
        });

        modelBuilder.Entity<UserProgram>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idprograms).HasColumnName("idprograms");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.DateLicens).HasColumnName("dateLicens");
            entity.Property(e => e.DateLicEnd).HasColumnName("dateLicEnd");

            entity.HasOne(d => d.IdprogramsNavigation).WithMany(p => p.UserPrograms)
                .HasForeignKey(d => d.Idprograms)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.UserPrograms)
                .HasForeignKey(d => d.Iduser)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
