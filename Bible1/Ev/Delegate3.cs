using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible1.Ev
{

    public class People3
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
         * 委托不同于string的一个特性：可以将多个方法赋给同一个委托，
         * 或者叫将多个方法绑定到同一个委托，当调用这个委托的时候，
         * 将依次调用其所绑定的方法。在这个例子中，语法如下：
         */
        void Run(string[] args)
        {
            GreetingDelegate delegate1;
            delegate1 = EnglishGreeting;       // 先给委托类型的变量赋值
            delegate1 += ChineseGreeting;       // 给此委托变量再绑定一个方法

            // 将先后调用 EnglishGreeting 与 ChineseGreeting 方法
            GreetPeople("Jimmy Zhang", delegate1);
            Console.ReadKey();

            //输出为：
            //Morning, Jimmy Zhang
            //早上好, Jimmy Zhang
        }
    }


}
