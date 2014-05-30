using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bible.多态
{
    public sealed class LonglyGuy
    {
        public void Run()
        {
            Say();
        }
        public void Say()
        {
            Console.WriteLine("Longly foo...");
        }

    }

    public class LonglyWoman
    {
        public void Run()
        {
            Say();
        }
        public virtual void Say()
        {
            Console.WriteLine("Longly 女人...");
        }
    }

    public class LonglyGirl : LonglyWoman
    {
        //public override void Say()
        //{
        //    //LonglyGirl foo = new LonglyGirl(); 打印女孩
        //    //LonglyWoman foo = new LonglyGirl(); 打印女孩
        //    Console.WriteLine("Longly 女孩...");
        //}

        public new void Say() //new ，与父类毫无关系，父类的Run永远不会调用到new 的Say
        //若要调用，必须直接用girl1.Say(); 而且不能声明为 LonglyWoman foo = new LonglyGirl();
        {
            Console.WriteLine("Longly 女孩...");
        }

    }

    public class LonglyDaughter : LonglyGirl
    {

    }
}
