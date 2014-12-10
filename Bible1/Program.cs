using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bible.Equals;
using Bible.EqualsDir;
using Bible.多态;
using Bible1.Ev;
using Bible1.线程;
using Bible1Lib;

namespace Bible
{
    class Program
    {
        static void Main(string[] args)
        {

            //OOMUtil.SampleRecursiveMethod(100);
            //FooB foo = new FooB();
            //foo.Run();

            //IFooContext foo = new FooContext();
            //Console.WriteLine(foo.GetType());
            //EvSample1.Run();
            //Ev2.Program.Run5();
            Polymorphism.Run();
            //FooController.Run();
            Console.ReadLine();
        }
    }
}
