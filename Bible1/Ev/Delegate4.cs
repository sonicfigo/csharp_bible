using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible1.Ev
{
    public class People4
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

        /*让我们再次对委托作个总结：
         * 使用委托可以将多个方法绑定到同一个委托变量，
         * 当调用此变量时(这里用“调用”这个词，是因为此变量代表一个方法)，可以依次调用所有绑定的方法。*/

        void Run(string[] args)
        {
            GreetingDelegate delegate1 = new GreetingDelegate(EnglishGreeting);
            delegate1 += ChineseGreeting;       // 给此委托变量再绑定一个方法

            // 将先后调用 EnglishGreeting 与 ChineseGreeting 方法
            GreetPeople("Jimmy Zhang", delegate1);
            Console.WriteLine();

            delegate1 -= EnglishGreeting; //取消对EnglishGreeting方法的绑定
            // 将仅调用 ChineseGreeting 
            GreetPeople("张子阳", delegate1);
            Console.ReadKey();

            //输出为：
            //Morning, Jimmy Zhang
            //早上好, Jimmy Zhang

            //早上好, 张子阳
        }
    }


}
