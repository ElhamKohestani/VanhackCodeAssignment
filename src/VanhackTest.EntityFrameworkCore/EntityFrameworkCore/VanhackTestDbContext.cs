using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using VanhackTest.Authorization.Roles;
using VanhackTest.Authorization.Users;
using VanhackTest.MultiTenancy;
using VanhackTest.Core.Entities;
using Abp.Domain.Repositories;
using VanhackTest.EntityFrameworkCore.Repositories;
using Abp.EntityFrameworkCore;

namespace VanhackTest.EntityFrameworkCore
{
    //[AutoRepositoryTypes(
    //    typeof(IRepository<>),
    //    typeof(IRepository<,>),
    //    typeof(VanhackTestRepositoryBase<>),
    //    typeof(VanhackTestRepositoryBase<,>)
    //)]
    public class VanhackTestDbContext :  AbpZeroDbContext<Tenant, Role, User, VanhackTestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseCategory> CourseCategories { get; set; }
        public virtual DbSet<CourseRecording> CourseRecordings { get; set; }
        public virtual DbSet<CourseAccessLevel> CourseAccessLevels { get; set; }

        public VanhackTestDbContext(DbContextOptions<VanhackTestDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course", "CRS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CourseCategoryID");
            });

            modelBuilder.Entity<CourseAccessLevel>(entity =>
            {
                entity.ToTable("CourseAccessLevel", "CRS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseAccessLevels)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseAccessLevel_CourseID");
            });


            modelBuilder.Entity<CourseCategory>(entity =>
            {
                entity.ToTable("CourseCategory", "CRS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryIdentifier)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });



            modelBuilder.Entity<CourseRecording>(entity =>
            {
                entity.ToTable("CourseRecordings", "CRS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseRecordings)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CourseRecordingCourseID");
            });
        }
    }
}
