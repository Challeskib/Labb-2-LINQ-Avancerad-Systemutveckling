﻿using Labb_2___LINQ_Avancerad_Systemutveckling.Data;
using Labb_2___LINQ_Avancerad_Systemutveckling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2___LINQ_Avancerad_Systemutveckling.Controllers
{
    internal class AddDataMethods
    {
        public void AddCourses()
        {
            using LinqLabb2Context context = new LinqLabb2Context();

            Course course = new Course()
            {
                CourseName = "SUT21",
                Teacher = context.Teachers.FirstOrDefault(t => t.Id == 1)
            };
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
            var course = context.Courses.FirstOrDefault(c => c.Id == 7); //Använder DbSet.Courses för att hämta course med id 8

            //Skapar en ny lista av Students i objektet 
            course.Students = new List<Student>()
            {
                //Väljer vilka students som ska ha course objekt 8 SUT21
                context.Students.FirstOrDefault(s => s.Id == 3),
                context.Students.FirstOrDefault(s => s.Id == 4),
            };

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
    }
}
