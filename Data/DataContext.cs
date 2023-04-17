using AvanceradDotNetLabb2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNetLabb2.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = THINKPAD; Initial Catalog=AvanceradDotNetLabb2;Integrated Security = True; TrustServerCertificate = True");
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public async Task SeedData()
        {
            try
            {
                Console.WriteLine("Trying to add data...");

                if (await Courses.AnyAsync() || await Students.AnyAsync() || await Subjects.AnyAsync() || await Teachers.AnyAsync())
                {
                    Console.WriteLine("Data already exists in DB, no data added.");
                    return;
                }

                var teacher1 = new Teacher { Name = "Mr. Smith" };
                var teacher2 = new Teacher { Name = "Ms. Johnson" };

                var subject1 = new Subject { Name = "Math" };
                var subject2 = new Subject { Name = "History" };
                var subject3 = new Subject { Name = "Programming" };

                teacher1.Subjects.Add(subject1);
                teacher1.Subjects.Add(subject2);
                teacher2.Subjects.Add(subject3);

                var course1 = new Course { Name = "SUT22" };

                course1.Subjects.Add(subject1);
                course1.Subjects.Add(subject2);
                course1.Subjects.Add(subject3);

                var student1 = new Student { Name = "John A", Course = course1, Teacher = teacher1 };
                var student2 = new Student { Name = "John B", Course = course1, Teacher = teacher2 };
                var student3 = new Student { Name = "Anna C", Course = course1, Teacher = teacher2 };

                Teachers.AddRange(teacher1, teacher2);
                 Subjects.AddRange(subject1, subject2, subject3);
                Courses.Add(course1);
                Students.AddRange(student1, student2, student3);

                await SaveChangesAsync();

                Console.WriteLine("Data added to all tables");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured, message: {e}");
            }
        }

        public async Task ClearAllTables()
        {
            try
            {
                Console.WriteLine("Trying to drop data...");

                Students.RemoveRange(Students);
                Courses.RemoveRange(Courses);
                Subjects.RemoveRange(Subjects);
                Teachers.RemoveRange(Teachers);

                await SaveChangesAsync();

                Console.WriteLine("All data cleared from tables");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured, message: {e}");
            }
        }
    }
}
