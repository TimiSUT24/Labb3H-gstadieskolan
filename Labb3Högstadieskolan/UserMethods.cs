using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Labb3Högstadieskolan.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3Högstadieskolan
{
    public class UserMethods
    {
        public void ShowAllStudents()
        {
            Console.Clear();
            Console.WriteLine("1. Sort by firstname\n" +     // Menu for users
                              "2. Sort by lastname");

            if (!int.TryParse(Console.ReadLine(), out int userChoice) || (userChoice != 1 && userChoice != 2))
            {
                Console.WriteLine("Invalid Choice");
                ShowAllStudents();
                return;
            }

            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("\n1. Ascedning sorting\n" +
                                      "2. Descending sorting");

                    if (!int.TryParse(Console.ReadLine(), out int sortByName) || (sortByName != 1 && sortByName != 2))
                    {
                        Console.WriteLine("Invalid Choice");
                        ShowAllStudents();
                        return;
                    }

                    if (sortByName == 1)
                    {   
                        OrderBy.OrderByFirstname();
                    }
                    else
                    {   
                        OrderBy.OrderByDescFirstname();
                    }
                    break;

                case 2:
                    Console.WriteLine("\n1. Ascedning sorting\n" +
                                      "2. Descending sorting");

                    if (!int.TryParse(Console.ReadLine(), out int sortByLastname) || (sortByLastname != 1 && sortByLastname != 2))
                    {
                        Console.WriteLine("Invalid Choice");
                        ShowAllStudents();
                        return;
                    }

                    if (sortByLastname == 1)
                    {                      
                        OrderBy.OrderByLastname();
                    }
                    else
                    {    
                        OrderBy.OrderByDescLastname();
                    }
                    break;
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            UserMenu.Menu();
        }

        public void ShowStudentsInClass()
        {
            Console.Clear();

            using (var context = new HögstadieskolaContext())   // Shows all classes first 
            {
                Console.WriteLine("Choose a class:");
                var showAllClasses = context.Classes.ToList();
                    
                foreach (var classes in showAllClasses)
                {
                    Console.WriteLine(classes.Classid + "." + " " + classes.Name);
                }
                                          
                if (!int.TryParse(Console.ReadLine(), out int chooseclass) || (chooseclass == 0)) // Then user chooses 
                {
                    Console.WriteLine("Invalid Choice");
                    ShowStudentsInClass();
                    return;
                }

                var showStudents = context.Students         // Get class with user input and shows students in that class 
                    .Where(s => s.Classid == chooseclass)
                    .Select(s => new { s.Name, s.Lastname, s.Classid, s.Class })
                    .ToList();           
                Console.WriteLine($"\nStudents in class {showStudents.FirstOrDefault().Class.Name}: ");             
                foreach (var Students in showStudents)          
                {
                    Console.WriteLine(Students.Name + " " + Students.Lastname);     // Shows firstname and lastname 
                }
                             
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            UserMenu.Menu();          

        }

        public void AddNewEmployee()
        {
            Console.Clear();           

            Console.WriteLine("In order to add an employee write in correct format like this:\n" +  
                "Firstname,Lastname,Epost,Number\n\n" +    
                "Add Employee:");                                   // User can add new employee 

            string add = Console.ReadLine().ToUpper();      
            string[] inputs = add.Split(',');           // Seperate each input with comma and put it in an string array 
            int.Parse(inputs[3]);
           
            if(inputs.Length > 4 || inputs.Length <= 0)
            {
                Console.WriteLine("Error");
            }
            
            using (var context = new HögstadieskolaContext())       // New employee gets added to database
            {               
                var addEmployee = new Personal { Name = inputs[0], Lastname = inputs[1], Epost = inputs[2], Number = inputs[3] };               
                context.Personals.Add(addEmployee);
                context.SaveChanges();
                Console.WriteLine($"Added Employee: {addEmployee.Name}");
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            UserMenu.Menu();
        }
    }
}
