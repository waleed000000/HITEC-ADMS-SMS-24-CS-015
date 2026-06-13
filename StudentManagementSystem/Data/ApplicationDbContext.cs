using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentManagementSystem.Models.Section> Sections { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public DbSet<FeePayment> FeePayments { get; set; }
        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<LibraryIssue> LibraryIssues { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<AcademicProgram> AcademicPrograms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentManagementSystem.Models.Section>()
                .HasOne(s => s.Faculty)
                .WithMany()
                .HasForeignKey(s => s.FacultyID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentManagementSystem.Models.Section>()
                .HasOne(s => s.Course)
                .WithMany()
                .HasForeignKey(s => s.CourseID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Section)
                .WithMany()
                .HasForeignKey(e => e.SectionID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AttendanceRecord>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AttendanceRecord>()
                .HasOne(a => a.Section)
                .WithMany()
                .HasForeignKey(a => a.SectionID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Enrollment)
                .WithMany()
                .HasForeignKey(g => g.EnrollmentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FeePayment>()
                .HasOne(f => f.Student)
                .WithMany()
                .HasForeignKey(f => f.StudentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LibraryIssue>()
                .HasOne(l => l.Student)
                .WithMany()
                .HasForeignKey(l => l.StudentID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}