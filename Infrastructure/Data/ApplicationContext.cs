using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Address> Addresss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Configuracion de User y tablas que heredan
            modelBuilder.Entity<User>()
                .HasDiscriminator<UserRole>("Role")
                .HasValue<Admin>(UserRole.Admin)
                .HasValue<Student>(UserRole.Student)
                .HasValue<Teacher>(UserRole.Teacher);

            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<Admin>()
                .ToTable("Users");

            modelBuilder.Entity<Student>()
                .ToTable("Users");

            modelBuilder.Entity<Teacher>()
                .ToTable("Users");
            #endregion

            #region Incluir propiedades con en la accion
            modelBuilder.Entity<Teacher>()
                .Navigation(t => t.Address)
                .AutoInclude();
            #endregion

            #region Relacion Address
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Address);
            #endregion

            #region Relacion Course
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .IsRequired();
            #endregion

            #region Relacion Grade
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Teacher)
                .WithMany(t => t.Grades)
                .HasForeignKey(g => g.TeacherId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.CourseId);
            #endregion

            #region Relacion Exam
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Exams)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Teacher)
                .WithMany(t => t.Exams)
                .HasForeignKey(e => e.TeacherId);

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Exams)
                .HasForeignKey(e => e.CourseId);
            #endregion

            #region Relacion Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.StudentId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Course)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CourseId);
            #endregion

            #region Relacion Module
            modelBuilder.Entity<Module>()
                .HasOne(m => m.Course)
                .WithMany(c => c.Modules)
                .HasForeignKey(m => m.CourseId);

            modelBuilder.Entity<Module>()
                .HasOne(m => m.Teacher)
                .WithMany(t => t.Modules)
                .HasForeignKey(m => m.TeacherId);
            #endregion
        }
    }
}
