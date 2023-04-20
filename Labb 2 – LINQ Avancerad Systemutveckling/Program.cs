using Labb_2___LINQ_Avancerad_Systemutveckling.Data;
using Labb_2___LINQ_Avancerad_Systemutveckling.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_2___LINQ_Avancerad_Systemutveckling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (LinqLabb2Context context = new LinqLabb2Context())
            {

                var teachersAndStudents = context.Courses
                     .Join(context.Teachers, c => c.Teacher.Id, t => t.Id, (c, t) => new { Course = c, Teacher = t });

                var teachersAndStudents1 = context.Courses.Include(c => c.Students).Include(t => t.Subjects);

                foreach (var item in teachersAndStudents1)
                {
                    Console.WriteLine(item.CourseName);
                    foreach (var student in item.Students)
                    {
                        Console.WriteLine(student.Name);
                    }
                }



                //foreach (var item in teachersAndStudents)
                //{
                //    Console.WriteLine(item.Teacher.Name + " ||||| " + item.Course.CourseName);
                //}






            };






        }

        public void AddCourses()
        {
            using LinqLabb2Context context = new LinqLabb2Context();

            Course course = new Course() { CourseName = "SUT21", Teacher = context.Teachers.FirstOrDefault(t => t.Id == 1) };
            context.Add(course);
        }

        public void AddStudents()
        {
            using LinqLabb2Context context = new LinqLabb2Context();


            List<Student> students = new List<Student>
            {
                new Student () { Name = "Charlie"},
                new Student () { Name = "Daniel"},
                new Student () { Name = "Peter"},
                new Student () { Name = "Elvin"},
                new Student () { Name = "Irma"},
                new Student () { Name = "Ursula"},
                new Student () { Name = "Damir"}
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }

        public void UpdateCourseStudent()
        {
            using LinqLabb2Context context = new LinqLabb2Context();

            //Här sparar vi ner course objekt = SUT21 = 8
            var course = context.Courses.FirstOrDefault(c => c.Id == 8); //Använder DbSet.Courses för att hämta course med id 8

            //Skapar en ny lista av Students i objektet 
            course.Students = new List<Student>()
            {
                //Väljer vilka students som ska ha course objekt 8 SUT21
                context.Students.FirstOrDefault(s => s.Id == 6),
                context.Students.FirstOrDefault(s => s.Id == 7),
            };

            //context.AddRange(course);
            context.SaveChanges();
        }

        public void AddCourseSubject()
        {
            using LinqLabb2Context context = new LinqLabb2Context();

            var selectCourse = context.Courses.FirstOrDefault(c => c.Id == 7); //Ska hämta courseCollectionOfSubjects
            var id = context.Subjects.FirstOrDefault(cs => cs.Id == 2); //Välj vilka ämnen
            var id1 = context.Subjects.FirstOrDefault(cs => cs.Id == 3);//Välj vilka ämnen

            selectCourse.Subjects = new List<Subject>()
            {
                id,
                id1,
            };
            context.SaveChanges();
        }

        public void AddSubjectTeacher()
        {
            using LinqLabb2Context context = new LinqLabb2Context();

            var selectSubject = context.Subjects.FirstOrDefault(s => s.Id == 3); //Hämta vilket subject
            var id = context.Teachers.FirstOrDefault(t => t.Id == 6); //Välj vilka lärare
            var id1 = context.Teachers.FirstOrDefault(t => t.Id == 7);//Välj vilka lärare

            selectSubject.Teachers = new List<Teacher>()
            {
                id,
                id1,

            };
            context.SaveChanges();
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

        public static void GetAllTeachersWithStudents()
        {
            using (LinqLabb2Context context = new LinqLabb2Context())
            {
                var teachersOfSubject1 = context.Teachers.Where(t => t.Subjects.Any(s => s.Id == 1));

                var studentsOfTeachers = context.Teachers.Where(t => t.Subjects.Any(s => s.Id == 1));




            };

        }


    }
}