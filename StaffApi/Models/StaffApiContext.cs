using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StaffApi.Models
{
    public partial class StaffApiContext : DbContext
    {
        public StaffApiContext()
        {
        }

        public StaffApiContext(DbContextOptions<StaffApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdministrativeStaff> AdministrativeStaff { get; set; }
        public virtual DbSet<SupportingStaff> SupportingStaff { get; set; }
        public virtual DbSet<TeachingStaff> TeachingStaff { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ROBHQ7Q;Database=School Database;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdministrativeStaff>(entity =>
            {
                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Staff)

                    .WithMany(p => p.AdministrativeStaff)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_AdministrativeStaff_Staff");
            });




            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasIndex(e => e.EmpId)
                    .IsUnique();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StaffType)
                        .HasColumnType("int");

            });

            modelBuilder.Entity<SupportingStaff>(entity =>
            {
                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.SupportingStaff)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_SupportingStaff_Staff");
            });

            modelBuilder.Entity<TeachingStaff>(entity =>
            {
                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TeachingStaff)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_TeachingStaff_Staff");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
