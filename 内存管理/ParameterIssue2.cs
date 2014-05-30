using System;

namespace Bible.内存管理
{


    public class ParameterIssue2
    {
        public static void Run()
        {
            Go();
            GoRef(); //1.GoRef()方法入栈
        }
        public static void Go()
        {
            Thing x = new Animal(1);
            int xh = x.GetHashCode();
            Switcharoo(x);
            Console.WriteLine("x is Animal    :   " + (x is Animal).ToString());//true
            Console.WriteLine("x is Vegetable :   " + (x is Vegetable).ToString());//false
            Console.WriteLine("x id           :   " + x.Id);
        }

        public static void Switcharoo(Thing pValue)// B4.参数pValue入栈 + B5.ｘ的值(MyInt对象的在栈中的指针地址)被拷贝到pValue中
        //即是pValue -> MyInt instance  
        //    x      -> MyInt instance
        {
            //即是 两个不同的指针，同时指向堆中的MyInt
            //todo 隔离出单独的正常情况(不new的情况，现象是很简单的)
            //所以改变pValue的属性，就是改变x指向的MyInt的属性（先不考虑变态的方法体中new的情况，把这个正常情况单独一个例子，等回头有空）

            pValue = new Vegetable(33); //变态的指向新的指针，只是为了说明问题，平时不要这么用，太难跟踪
            int ph = pValue.GetHashCode();
        }

        public static void GoRef()
        {
            //2.x指针入栈
            Thing x = new Animal(1);     //3.Animal对象实例化到堆中
            SwitcharooRef(ref x);       //4.Switcharoo()方法入栈
            Console.WriteLine("x is Animal    :   "+ (x is Animal).ToString());//false
            Console.WriteLine("x is Vegetable :   "+ (x is Vegetable).ToString());//true
            Console.WriteLine("x id           :   " + x.Id);
        }

        public static void SwitcharooRef(ref Thing pValue) // 5.参数pValue入栈，但不是copy x的指针值了，而是直接指向ｘ，相当于绑定一起的两个指针
        //即是 pValue -> x ->MyInt instance
        {
            // 6.Vegetable对象实例化到堆中
            // 7.x的值通过被指向Vegetable对象地址的pValue值所改变。
            //
            //此时pValue的new操作，等于也让x = new了。
            pValue =  new Vegetable(22);
        }
    }


    public class Thing
    {
        public Thing(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class Animal : Thing
    {
        public Animal(int id)
            : base(id)
        {
        }
        public int Weight;
    }

    public class Vegetable : Thing
    {
        public Vegetable(int id)
            : base(id)
        {
        }
        public int Length;
    }



}
