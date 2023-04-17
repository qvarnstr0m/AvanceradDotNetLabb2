using AvanceradDotNetLabb2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AvanceradDotNetLabb2
{
    public class Controllers
    {
        private readonly DataContext _dataContext;

        public Controllers(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Menu()
        {
            Console.Clear();
            Console.WriteLine("1. List math teachers");
            Console.WriteLine("2. List students with teachers");
            Console.WriteLine("3. Check if subject exists");
            Console.WriteLine("4. Edit subject");
            Console.WriteLine("5. Edit students teacher");
            Console.Write("\nEnter choice:");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Menu();
            }

            switch (input)
            {
                case 1:
                    await ListMath();
                    break;
                case 2:
                    await ListStudentsWithTeacher();
                    break;
                case 3:
                    await WriteContainsCourse();
                    break;
                case 4:
                    await EditSubject();
                    break;
                case 5:
                    await ChangeStudentsTeacher();
                    break;
                default:
                    await Menu();
                    break;
            }
            
        }

        public async Task ListMath()
        {
            Console.Clear();
            var mathTeachers = await _dataContext.Teachers
            .Include(t => t.Subjects)
            .Where(t => t.Subjects.Any(s => s.Name == "Math"))
            .ToListAsync();

            foreach (var teacher in mathTeachers)
            {
                Console.WriteLine($"Math teacher: {teacher.Name}");
            }
            Console.WriteLine("Math teachers listed.");
            Console.ReadKey();
            await Menu();
        }

        public async Task ListStudentsWithTeacher()
        {
            Console.Clear();
            var studentsTeachers = await _dataContext.Students
            .Include(t => t.Teacher)
            .ToListAsync();

            foreach (var student in studentsTeachers)
            {
                Console.WriteLine($"Student: {student.Name} Teacher: {student.Teacher.Name}");
            }
            Console.WriteLine("Students listed.");
            Console.ReadKey();
            await Menu();
        }

        public async Task WriteContainsCourse()
        {
            Console.Clear();
            Console.Write("Enter course name: ");
            string input = Console.ReadLine();
            Console.WriteLine(await _dataContext.Subjects.AnyAsync(s => s.Name == input) ? $"Yes {input}" : $"No {input}");
            Console.ReadKey();
            await Menu();
        }

        public async Task EditSubject()
        {
            Console.Clear();
            Console.Write("Enter name of subject to change: ");
            string input = Console.ReadLine();

            var subjectToChange = await _dataContext.Subjects.FirstOrDefaultAsync(s => s.Name == input);

            if (subjectToChange == null)
            {
                Console.WriteLine("Not found.");
                Console.ReadKey();
                await Menu();
            }

            Console.Write("Enter new subject: ");
            subjectToChange.Name = Console.ReadLine();

            await _dataContext.SaveChangesAsync();

            Console.WriteLine("Course name changed.");
            Console.ReadKey();
            await Menu();
        }

        public async Task ChangeStudentsTeacher()
        {
            Console.Clear();

            Console.Write("Enter name of student: ");
            var studentToChange = await _dataContext.Students.FirstOrDefaultAsync(s => s.Name == Console.ReadLine());

            if (studentToChange == null)
            {
                Console.WriteLine("Not found.");
                Console.ReadKey();
                await Menu();
            }

            Console.Write("Enter name of new teacher: ");
            var newTeacher = await _dataContext.Teachers.FirstOrDefaultAsync(t => t.Name == Console.ReadLine());

            if (newTeacher == null)
            {
                Console.WriteLine("Not found.");
                Console.ReadKey();
                await Menu();
            }

            studentToChange.Teacher = newTeacher;

            await _dataContext.SaveChangesAsync();

            Console.WriteLine("Teacher changed.");
            Console.ReadKey();
            await Menu();
        }
    }
}
