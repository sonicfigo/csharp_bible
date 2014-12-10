using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible1.Ev
{
    //阅读顺序 4.1 -> 4.2
    // 5.1 -> 5.2
    public class Ev2
    {
        //定义委托，它定义了可以代表的方法的类型
        public delegate void GreetingDelegate(string name);

        //新建的GreetingManager类
        public class GreetingManager
        {
            /*4.1 既然可以声明委托类型的变量(在上例中是delegate1)，我们何不将这个变量封装到 GreetManager类中？
            于是，我们改写GreetManager类，像这样：
            在GreetingManager类的内部声明delegate1变量
            */
            public GreetingDelegate delegate1;


            /*5.1
             尽管这样达到了我们要的效果，但是似乎并不美气，光是第一个方法注册用“=”，
             * 第二个用“+=”就让人觉得别扭。此时，轮到Event出场了，
             * C# 中可以使用事件来专门完成这项工作，我们改写GreetingManager类，它变成了这个样子：
             * 
             * 这一次我们在这里声明一个事件:
             * 很容易注意到：MakeGreet 事件的声明与之前委托变量delegate1的声明唯一的区别是多了一个event关键字。看到这里，
             * 你差不多明白到：事件其实没什么不好理解的:
             * 
             * 声明一个事件不过类似于声明一个委托类型的变量而已。
             * */
            public event GreetingDelegate MakeGreet;

            public void GreetPeople(string name, GreetingDelegate MakeGreeting)
            {
                MakeGreeting(name);
            }

            //6.1
            public void Do(string name)
            {
                MakeGreet(name);
            }
        }

        public class Program
        {
            private static void EnglishGreeting(string name)
            {
                Console.WriteLine("Morning, " + name);
            }

            private static void ChineseGreeting(string name)
            {
                Console.WriteLine("早上好, " + name);
            }

            //4.2现在，我们可以这样使用这个委托变量：
            static void Run4(string[] args)
            {
                GreetingManager gm = new GreetingManager();
                gm.delegate1 = EnglishGreeting;
                gm.delegate1 += ChineseGreeting;

                gm.GreetPeople("Jimmy Zhang", gm.delegate1);
            }

            
            //5.2
            public static void Run5()
            {
                GreetingManager gm = new GreetingManager();
                /*
                
                gm.MakeGreet = EnglishGreeting;                     // 编译错误1
                gm.MakeGreet += ChineseGreeting;

                gm.GreetPeople("Jimmy Zhang", gm.MakeGreet);              //编译错误2
                
                */

                /*
                 * 现在已经很明确了：MakeGreet 事件确实是一个GreetingDelegate类型的委托，
                 * 只不过不管是不是声明为public，它总是被声明为private。
                 * 另外，它还有两个方法，分别是add_MakeGreet和remove_MakeGreet，
                 * 这两个方法分别用于注册委托类型的方法和取消注册，
                 * 实际上也就是： “+= ”对应 add_MakeGreet，“-=”对应remove_MakeGreet。
                 * 而这两个方法的访问限制取决于声明事件时的访问限制符。
                 */

                //6.2, 应该使用:
                gm.MakeGreet += ChineseGreeting;
                gm.Do("A。只有gm自己有权限，进行事件添加和执行委托");
                gm.Do("B。只有gm自己有权限，进行事件添加和执行委托");

            }
        }
    }
}
