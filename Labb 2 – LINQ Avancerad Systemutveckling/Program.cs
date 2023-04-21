using Labb_2___LINQ_Avancerad_Systemutveckling.Controllers;
using Labb_2___LINQ_Avancerad_Systemutveckling.Data;
using Labb_2___LINQ_Avancerad_Systemutveckling.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Labb_2___LINQ_Avancerad_Systemutveckling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utility.Menu();
        }
        public static void GetAllMathTeachers()
        {
            using (LinqLabb2Context context = new LinqLabb2Context())
            {
                var teachersOfSubject1 = context.Teachers.Where(t => t.Subjects.Any(s => s.Id == 1));

                Console.WriteLine("All Math Teachers");
                foreach (var item in teachersOfSubject1)
                {
                    Console.WriteLine(item.Name);
                }
            };
        }

        public static void PrintAllTeachersWithStudents()
        {
            using (LinqLabb2Context context = new LinqLabb2Context())
            {
                var teacherCourseStudent = context.Courses
                      .Include(c => c.Teacher)
                      .Include(c => c.Students)
                      .SelectMany(c => c.Students
                      .Select
                      (s => new
                      {
                          StudentName = s.Name,
                          TeacherName = c.Teacher.Name,
                          Course = c.CourseName
                      }));

                foreach (var item in teacherCourseStudent)
                {
                    Console.WriteLine($"Student: {item.StudentName}, Teacher: {item.TeacherName}");
                };

            };
        }

        public static void FindProgramming()
        {
            using (LinqLabb2Context context = new LinqLabb2Context())
            {

                bool subjectExists = context.Subjects.Any(s => s.SubjectName == "Programmering");

                if (subjectExists)
                {
                    Console.WriteLine($"Programmering Exists");
                }
                else
                {
                    Console.WriteLine($"Programmering does NOT exist!!!");
                }
            }
        }

        public static void EditSubjectToOop()
        {
            using (LinqLabb2Context context = new LinqLabb2Context())
            {
                var subjectToUpdate = context.Subjects
                    .FirstOrDefault(s => s.SubjectName == "Programmering2" || s.SubjectName == "OOP");

                Console.WriteLine("List of all Subjects");
                foreach (var item in context.Subjects)
                {
                    Console.WriteLine("Subject: " + item.SubjectName);
                }

                Console.WriteLine("Press key to continue");
                Console.ReadKey();

                if (subjectToUpdate.SubjectName == "Programmering2")
                {
                    subjectToUpdate.SubjectName = "OOP"; // update the name
                    context.SaveChanges(); // save changes to the database
                    Console.WriteLine();
                    Console.WriteLine($"Subject name updated to {subjectToUpdate.SubjectName}.");
                }
                else if (subjectToUpdate.SubjectName == "OOP")
                {
                    subjectToUpdate.SubjectName = "Programmering2"; // update the name
                    context.SaveChanges(); // save changes to the database
                    Console.WriteLine();
                    Console.WriteLine($"Subject name updated to {subjectToUpdate.SubjectName}.");
                }
                else
                {
                    Console.WriteLine("Did not work");
                }
               
                Console.WriteLine("Press key to view the changes: ");
                Console.WriteLine("------------------------");
                Console.WriteLine();

                Console.ReadKey();

                Console.WriteLine("List of all Subjects");
                foreach (var item in context.Subjects)
                {
                    Console.WriteLine("Subject: " + item.SubjectName);
                }
            };
        }

        public static void UpdateTeacherToReidarOrAnas()
        {
            using (LinqLabb2Context context = new LinqLabb2Context())
            {
                var course = context.Courses.FirstOrDefault(c => c.Id == 8);

                var Anas = context.Teachers.FirstOrDefault(t => t.Id == 4);
                var Reidar = context.Teachers.FirstOrDefault(t => t.Id == 5);


                PrintAllTeachersWithCourses();

                if (course.Teacher == Anas)
                {
                    course.Teacher = Reidar;
                }
                else if (course.Teacher == Reidar)
                {
                    course.Teacher = Anas;
                }

                context.SaveChanges();

                Console.WriteLine("Press key to view the changes: ");
                Console.WriteLine("------------------------");
                Console.ReadKey();
                PrintAllTeachersWithCourses();

            };
        }

        public static void PrintAllTeachersWithCourses()
        {
            using (LinqLabb2Context context = new LinqLabb2Context())
            {
                var teacherCourseStudent = context.Courses
                      .Include(c => c.Teacher)
                      .Include(c => c.Students)
                      .SelectMany(c => c.Students
                      .Select
                      (s => new
                      {
                          StudentName = s.Name,
                          TeacherName = c.Teacher.Name,
                          Course = c.CourseName
                      }));

                Console.WriteLine();
                Console.WriteLine("Student records with teachers:");
                foreach (var item in teacherCourseStudent)
                {
                    Console.WriteLine($"Student: {item.StudentName}, Teacher: {item.TeacherName}");
                };

            };
        }
    }
}