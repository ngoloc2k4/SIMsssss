using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIM_Project.Models;

namespace SIM_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLearningOfStudent> CourseLearningOfStudents { get; set; }
        public DbSet<CourseTeachOfTeacher> CourseTeachOfTeachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Programmer> Programmers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many relationship: Teacher - CourseTeachOfTeacher
            modelBuilder.Entity<CourseTeachOfTeacher>()
                .HasOne(ct => ct.Teacher)
                .WithMany(t => t.CourseTeachings)
                .HasForeignKey(ct => ct.TeacherID);

            // One-to-Many relationship: Course - CourseTeachOfTeacher
            modelBuilder.Entity<CourseTeachOfTeacher>()
                .HasOne(ct => ct.Course)
                .WithMany(c => c.CourseTeachings)
                .HasForeignKey(ct => ct.CourseID);

            // One-to-Many relationship: Student - CourseLearningOfStudent
            modelBuilder.Entity<CourseLearningOfStudent>()
                .HasOne(cl => cl.Student)
                .WithMany(s => s.CourseLearnings)
                .HasForeignKey(cl => cl.StudentID);

            // One-to-Many relationship: Course - CourseLearningOfStudent
            modelBuilder.Entity<CourseLearningOfStudent>()
                .HasOne(cl => cl.Course)
                .WithMany(c => c.CourseLearnings)
                .HasForeignKey(cl => cl.CourseID);

            // One-to-Many relationship: Semester - Course
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Semester)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.SemesterID);
        }

    }
}