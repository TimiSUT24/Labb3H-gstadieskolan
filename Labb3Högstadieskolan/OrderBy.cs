using Labb3Högstadieskolan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Högstadieskolan
{
    public class OrderBy
    {
        public static void OrderByFirstname()
        {
            Console.Clear();
            using (var context = new HögstadieskolaContext())  // Order by firstname with ascending sorting
            {
                var OrderByFirstName = context.Students
               .OrderBy(s => s.Name).ToList();
                Console.WriteLine("Students:");
                foreach (var students in OrderByFirstName)
                {
                    Console.WriteLine(students.Name + " " + students.Lastname);
                }
            }
        }

        public static void OrderByDescFirstname()
        {
            Console.Clear();
            using (var context = new HögstadieskolaContext()) // Order by firstname with descending sorting
            {
                var OrderByDescFirstName = context.Students
                .OrderByDescending(s => s.Name).ToList();
                Console.WriteLine("Students:");
                foreach (var students in OrderByDescFirstName)
                {
                    Console.WriteLine(students.Name + " " + students.Lastname);
                }
            }
        }

        public static void OrderByLastname()
        {
            Console.Clear();
            using (var context = new HögstadieskolaContext()) // Order by lastname with ascending sorting
            {
                var OrderByLastname = context.Students
                .OrderBy(s => s.Lastname).ToList();
                Console.WriteLine("Students:");
                foreach (var students in OrderByLastname)
                {
                    Console.WriteLine(students.Name + " " + students.Lastname);
                }
            }
        }

        public static void OrderByDescLastname()
        {
            Console.Clear();
            using (var context = new HögstadieskolaContext()) // Order by lastname with descending sorting
            {
                var OrderByDescLastname = context.Students
                .OrderByDescending(s => s.Lastname).ToList();
                Console.WriteLine("Students:");
                foreach (var students in OrderByDescLastname)
                {
                    Console.WriteLine(students.Name + " " + students.Lastname);
                }
            }
        }
    }

}
