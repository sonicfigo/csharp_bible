using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/*
 * owner        拥有者
 * ready queue  就绪队列
 * wait queue   等待队列
 */
namespace Bible1.线程
{
    public class MonitorThreadTest
    {
        public static void Run()
        {
            new Thread(A).Start();
            new Thread(B).Start();
            new Thread(C).Start();
            Console.ReadLine();
        }

        public static object lockObj = new object();
        static void A()
        {
            lock (lockObj)               //进入就绪队列
            {
                Thread.Sleep(1000);
                Monitor.Pulse(lockObj); //相应的Monitor.PulseAll则打开门放所有等待队列中的线程到就绪队列
                Monitor.Wait(lockObj);   //自我流放到等待队列
            }
            Console.WriteLine("A exit...");
            string sdf = "sdfsdf";
        }
        public static void B()
        {
            Thread.Sleep(500);
            lock (lockObj)               //进入就绪队列
            {
                Monitor.Pulse(lockObj);
            }
            Console.WriteLine("B exit...");
        }
        public static void C()
        {
            Thread.Sleep(800);
            lock (lockObj)               //进入就绪队列
            {
            }
            Console.WriteLine("C exit...");
        }
    }
}
