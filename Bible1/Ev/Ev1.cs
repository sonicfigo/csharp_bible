using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible1.Ev
{
    public class Ev1
    {
        //定义委托，它定义了可以代表的方法的类型
        public delegate void GreetingDelegate(string name);

        //新建的GreetingManager类
        public class GreetingManager
        {
            public void GreetPeople(string name, GreetingDelegate MakeGreeting)
            {
                MakeGreeting(name);
            }
        }

        class Program
        {
            private static void EnglishGreeting(string name)
            {
                Console.WriteLine("Morning, " + name);
            }

            private static void ChineseGreeting(string name)
            {
                Console.WriteLine("早上好, " + name);
            }

            static void Run(string[] args)
            {
                // ... ...

                //1.这个时候，如果要实现前面演示的输出效果，Run方法我想应该是这样的：
                GreetingManager gm = new GreetingManager();
                gm.GreetPeople("Jimmy Zhang", EnglishGreeting);
                gm.GreetPeople("张子阳", ChineseGreeting);
            }

            //2.现在，假设我们需要使用上一节学到的知识，将多个方法绑定到同一个委托变量，该如何做呢？让我们再次改写代码：
            static void Run2(string[] args)
            {
                GreetingManager gm = new GreetingManager();
                GreetingDelegate delegate1;
                delegate1 = EnglishGreeting;
                delegate1 += ChineseGreeting;

                gm.GreetPeople("Jimmy Zhang", delegate1);
            }
        }
    }
}
