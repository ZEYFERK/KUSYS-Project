using KUSYSDemo.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace KUSYSDemo.Models
{
    public class DataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2L2N1J6;Database=KUSYSDemo;integrated security=true");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "User" }
                );



            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = "CSI101", CourseName = "Introduction to Computer Science" },
                new Course { CourseId = "CSI102", CourseName = "Algorithms" },
                new Course { CourseId = "MAT101", CourseName = "Calculus" },
                new Course { CourseId = "PHY101", CourseName = "Physics" }
                );


            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, FirstName = "Deneme1", LastName = "Öğrenci1", BirthDate = Convert.ToDateTime("1998-10-11"), RoleId = 1, LoginUserName = "Admin1", LoginPassword = "111" },
                new Student { StudentId = 2, FirstName = "Deneme2", LastName = "Öğrenci2", BirthDate = Convert.ToDateTime("1999-11-16"), RoleId = 1, LoginUserName = "Admin2", LoginPassword = "111" },
                new Student { StudentId = 3, FirstName = "Deneme3", LastName = "Öğrenci3", BirthDate = Convert.ToDateTime("1994-01-22"), RoleId = 1, LoginUserName = "Admin3", LoginPassword = "111" },
                new Student { StudentId = 4, FirstName = "Deneme4", LastName = "Öğrenci4", BirthDate = Convert.ToDateTime("1995-03-12"), RoleId = 2, LoginUserName = "User3", LoginPassword = "111" },
                new Student { StudentId = 5, FirstName = "Deneme5", LastName = "Öğrenci5", BirthDate = Convert.ToDateTime("1996-05-23"), RoleId = 2, LoginUserName = "User4", LoginPassword = "111" }
                );


        }
    }
}

