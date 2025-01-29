using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Högstadieskolan
{
    public static class UserMenu
    {
        public static void Menu()
        {
            var userMethods = new UserMethods();

            Console.WriteLine("1. Show All Students\n" +        // Start menu with 3 different user choices 
                "2. Show Students In A Class\n" +
                "3. Add New Employees\n" + 
                "4. Exit");
           
            if (!int.TryParse(Console.ReadLine(), out int userChoice) || (userChoice >= 5 || userChoice <= 0))
            {
                Console.WriteLine("Invalid Choice");
                Console.Clear();
                Menu();
                return;
            }

            switch (userChoice)
            {
                case 1:                   
                    userMethods.ShowAllStudents();
                    break;
                case 2:
                    userMethods.ShowStudentsInClass();
                    break;
                case 3:
                    userMethods.AddNewEmployee();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;              
            }
        }
    }
}
