using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bible.EqualsDir
{
    public static class GuyCompare
    {
        public static void Run()
        {
            _run1();
            Printer.Print("");
            _run2();
            Printer.Print("");
            _list1();
        }

        private static void _run1()
        {
            Guy joe1 = new Guy("Joe", 37, 100);
            Guy joe2 = joe1;
            Console.WriteLine(Object.ReferenceEquals(joe1, joe2)); // True
            Console.WriteLine(joe1.Equals(joe2)); // True
            Console.WriteLine(Object.ReferenceEquals(null, null)); // True
            

            joe2 = new Guy("Joe", 37, 100);
            Console.WriteLine(Object.ReferenceEquals(joe1, joe2));// False
            Console.WriteLine(joe1.Equals(joe2));  // False
           
             
             
        }
        private static void _list1()
        {
            Guy joe1 = new Guy("joe1", 18, 10000);
            List<Guy> guys = new List<Guy>()
                {
                    new Guy("Bob", 42, 125),
                    new EquatableGuy(joe1.Name, joe1.Age, joe1.Cash), //以此实例的Equals为主. 而不是joe1的实例的Equals
                    new Guy("Ed", 39, 95)
                };
            Printer.Print(guys.Contains(joe1).ToString());
            // List.Contains() will go through its contents and call each object's Equals() method
            // to compare it with the reference you pass to it.Console.WriteLine(guys.Contains(joe1));                 // True
        }
        private static void _run2()
        {
            // Guy.Equals() will only return true if the actual values of the objects are the same.

            EquatableGuy joe1 = new EquatableGuy("Joe", 37, 100);
            EquatableGuy joe2 = new EquatableGuy("Joe", 37, 100);
            Console.WriteLine(Object.ReferenceEquals(joe1, joe2)); // False
            Console.WriteLine(joe1.Equals(joe2));                   // True

            joe1.GiveCash(50);
            Console.WriteLine(joe1.Equals(joe2));        // False          

            joe2.GiveCash(50);
            Console.WriteLine(joe1.Equals(joe2));     // True  
        }


    }
}
