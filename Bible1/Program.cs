using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bible.Equals;
using Bible.EqualsDir;
using Bible.多态;

namespace Bible
{
    class Program
    {
        static void Main(string[] args)
        {

            //OOMUtil.SampleRecursiveMethod(100);
            FooB foo = new FooB();
            foo.Run();
            

            Console.ReadLine();
        }
    }
}
