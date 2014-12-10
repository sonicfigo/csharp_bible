using System;

namespace Bible.多态
{
    public class Person
    {
        public virtual void PrintAge(int age)
        {
            Console.WriteLine("person age " + age);
        }
    }

    public class Son : Person
    {
        public override void PrintAge(int age)//override 只要是
        {
            Console.WriteLine("son(override) age " + age);
        }
    }

    public class Daughter : Person
    {
        public new void PrintAge(int age) //new 只有声明为daughter时用到
        {
            Console.WriteLine("daughter(new) age " + age);
        }
    }


    //多态的例子，用于理解 string 是 引用类型，但对比同样的字符串却为何返回 True (CompareIssue提及的方法)
    /*
     * Object 的 public virtual  bool Equals(object obj); 
     * 被String 的 public override bool Equals(object obj) 重写
     * 
     * 故多态使用 Equals时， 返回true
     * 
     * 但 == 操作符没有没有被重写，故 多态使用 ==时， 返回false
     */
    public static class Polymorphism
    {
        public static void Run()
        {
            Person father = new Person();
            father.PrintAge(30); //person age 30

            Person son1 = new Son();
            son1.PrintAge(10); //son(override) age 10, 多态 用的是Son的文字

            Son son2 = new Son();
            son2.PrintAge(10);//son(override) age 10

            Person daughter = new Daughter();
            daughter.PrintAge(6);//person age 6

            Daughter daughter2 = new Daughter();
            daughter2.PrintAge(6);//daughter(new) age 6
            RealWorldStringIssue();
        }



        public static void RealWorldStringIssue()
        {
            Console.WriteLine("重载了String的equals方法，使string对象用起来就像是值类型一样");
            string a = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            string b = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            Console.WriteLine(a == b);      //True
            Console.WriteLine(a.Equals(b)); //True

            object g = a;
            object h = b;
            Console.WriteLine("转为Object后, object g 和object h 内存中两个不同的对象，而且==方法没有被重写。所以在栈中的指针指向堆的对象是不相同的，故不相等, ");
            Console.WriteLine("g == h:      " + (g == h));      // g == h:      False

            Console.WriteLine("而g.equals(h)用的是sting的equals()方法故相等（多态）");
            Console.WriteLine("g.Equals(h):     " + g.Equals(h)); //g.Equals(h):     True
            Console.WriteLine(g.GetHashCode()); //327419862
            Console.WriteLine(h.GetHashCode()); //327419862

            // == 和Equals 还是不同的
        }
    }


    
}
