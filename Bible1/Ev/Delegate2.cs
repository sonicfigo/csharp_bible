using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible1.Ev
{
    //委托写法
    public class People2
    {
        public delegate void GreetingDelegate(string name);

        public void GreetPeople(string name, GreetingDelegate makeGreeting)
        {
            makeGreeting(name);
        }

        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }

        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }

        /* 
         * 对委托做一个总结：
         * 委托是一个类，它定义了方法的类型，使得可以将方法当作另一个方法的参数来进行传递，
         * 这种将方法动态地赋给参数的做法，可以避免在程序中大量使用If-Else(Switch)语句，同时使得程序具有更好的可扩展性。
         */
        void Run(string[] args)
        {
            GreetPeople("Jimmy Zhang", EnglishGreeting);
            GreetPeople("张子阳", ChineseGreeting);
            Console.ReadKey();
        }
    }


}
