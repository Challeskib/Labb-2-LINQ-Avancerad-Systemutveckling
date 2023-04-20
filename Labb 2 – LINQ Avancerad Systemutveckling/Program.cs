using Labb_2___LINQ_Avancerad_Systemutveckling.Data;
using Labb_2___LINQ_Avancerad_Systemutveckling.Models;

namespace Labb_2___LINQ_Avancerad_Systemutveckling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using LinqLabb2Context context = new LinqLabb2Context();


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
    }
}