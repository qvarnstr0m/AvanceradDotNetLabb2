// See https://aka.ms/new-console-template for more information
using AvanceradDotNetLabb2.Data;
using AvanceradDotNetLabb2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

Console.WriteLine("Hello, World!");

using DataContext dataContext = new DataContext();
//await dataContext.ClearAllTables(); 
await dataContext.SeedData();

Console.WriteLine();


// List all teachers teaching Math
var mathTeachers = await dataContext.Teachers
    .Include(t => t.Subjects)
    .Where(t => t.Subjects.Any(s => s.Name == "Math"))
    .ToListAsync();

foreach (var teacher in mathTeachers)
{
    Console.WriteLine($"Math teacher: {teacher.Name}");
}

Console.WriteLine();

// List all students with their teachers
var studentsTeachers = await dataContext.Students
    .Include(t => t.Teacher)
    .ToListAsync();

foreach (var student in studentsTeachers)
{
    Console.WriteLine($"Student: {student.Name} Teacher: {student.Teacher.Name}");
}

Console.WriteLine();

// Does Subjects contain "programmering1"
Console.WriteLine(await dataContext.Subjects.AnyAsync(s => s.Name == "programmering1") ? "Yes programmering1" : "No programmering1");

Console.WriteLine();

// Edit subject "Math" to "Algebra" and back again
var mathSubject = await dataContext.Subjects.FirstOrDefaultAsync(s => s.Name == "Math");
Console.WriteLine($"Subject name: {mathSubject.Name}");
mathSubject.Name = "Algebra";
await dataContext.SaveChangesAsync();
Console.WriteLine(await dataContext.Subjects.AnyAsync(s => s.Name ==  "Math") ? "Math exists" : "Math does not exist");
var algebraSubject = await dataContext.Subjects.FirstOrDefaultAsync(s => s.Name == "Algebra");
Console.WriteLine($"Subject name: {algebraSubject.Name}");
algebraSubject.Name = "Math";
await dataContext.SaveChangesAsync();
Console.WriteLine(await dataContext.Subjects.AnyAsync(s => s.Name == "Math") ? "Math exists again" : "Math does not exist");

Console.WriteLine();

// Change students teacher and back again
var studentToChange = await dataContext.Students.FirstOrDefaultAsync(s => s.Name == "Anna C");
var studentsTeacher = await dataContext.Teachers.FirstOrDefaultAsync(s => s.Id == studentToChange.Teacher.Id);
Console.WriteLine($"Student name: {studentToChange.Name} Teacher: {studentsTeacher.Name}");
studentToChange.Teacher = await dataContext.Teachers.FirstOrDefaultAsync(t => t.Id == 7);
await dataContext.SaveChangesAsync();
var studentToChange2 = await dataContext.Students.FirstOrDefaultAsync(s => s.Name == "Anna C");
var studentsTeacher2 = await dataContext.Teachers.FirstOrDefaultAsync(s => s.Id == studentToChange2.Teacher.Id);
Console.WriteLine($"Student name: {studentToChange2.Name} Teacher: {studentsTeacher2.Name}");
studentToChange.Teacher = await dataContext.Teachers.FirstOrDefaultAsync(t => t.Id == 8);
await dataContext.SaveChangesAsync();