using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bible.多态
{
    public class FooA
    {
        public void Run()
        {
            //Say();
            Laugh();
        }

        public virtual void Say()
        {
            Printer.Print("FooA");
        }

        protected void Laugh()
        {
            Printer.Print("hehe");
        }



    }

    public class FooB : FooA
    {
        public sealed override void Say() //override 将父子联系起来
            //new 将父子隔离
        {
            Printer.Print("FooB...........");
        }

        protected new void Laugh()
        {
            Printer.Print("haha---------");
        }
    }

    public class FooC : FooB
    {
        public new void Say()
        {
            Printer.Print("FooC...........");
        }
    }

}
