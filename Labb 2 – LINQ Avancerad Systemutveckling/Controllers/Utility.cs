using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2___LINQ_Avancerad_Systemutveckling.Controllers
{
    internal class Utility
    {
        public static void Menu()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("|              SWITCH MENU                  |");
            Console.WriteLine("============================================");
            Console.WriteLine("|  Please choose an option:                 |");
            Console.WriteLine("|  1. Get Math Teachers                     |");
            Console.WriteLine("|  2. Get all Students with Teachers        |");
            Console.WriteLine("|  3. Contains Programmering                |");
            Console.WriteLine("|  4. Edit Programmering2 / OOP             |");
            Console.WriteLine("|  5. Update Student, new teacher Reidar    |");
            Console.WriteLine("|  6. Exit program                          |");
            Console.WriteLine("============================================");

            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("You chose to get Math Teachers.");
                    Program.GetAllMathTeachers();
                    ReturnToMenu();
                    break;
                case 2:
                    Console.WriteLine("You chose to get all Students with Teachers.");
                    Program.PrintAllTeachersWithStudents();
                    ReturnToMenu();
                    break;
                case 3:
                    Console.WriteLine("You chose to search for 'Programmering'.");
                    Program.FindProgramming();
                    ReturnToMenu();
                    break;
                case 4:
                    Console.WriteLine("You chose to edit subject.");
                    Program.EditSubjectToOop();
                    ReturnToMenu();
                    break;
                case 5:
                    Console.WriteLine("You chose to update a Student with new teacher Reidar or Anas.");
                    Program.UpdateTeacherToReidarOrAnas();
                    ReturnToMenu();
                    break;
                case 6:
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine();

        }

        public static void ReturnToMenu()
        {
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadLine();
            Console.Clear();
            Menu();
        }
    }
}
