using System;
using Bible.多态;

namespace Bible.Equals
{
    //equals , ==  object.ReferenceEquals() 的区别，何时使用
    /* 结论：
     * 
     * 
     * Equals:
     * 重写以后，用来对比内容，而不对比真实引用地址
     * 
     * ==:
     * 对比地址, 速度更快，当要对比null 或 empty string时，使用==
     * 
     * 
     * object.ReferenceEquals(objA, objB)  相当于  ==
     * 
     * 
     * 
     * 引用类型：当你要对比内容，而不对比真实引用地址时，使用Equals(自己重写)
     * String为特例，直接使用 == 更为可读。
     * 
     * 值类型：直接使用 == 提高代码可读性。
     * 但是如果一个值类型overload了 == 操作符，将会变得棘手，有可能 == 的意义与Equals不同了。
     * 所以不要重写值类型的操作符
     * 
     * 
     * 
     */
    public static class EqualsIssue
    {
        public static void Run()
        {
            Console.WriteLine("*****对于值类型，如果对象的值相等，则 == 返回 true，否则返回 false");
            _valueEqualsMethod();
            Console.WriteLine();
            _valueEqualsOperation();

            Console.WriteLine("\r\n*****对于string 以外的引用类型，如果两个对象引用同一个对象，则 == 返回 true");
            _objectEqualsMethod();
            Console.WriteLine();
            _objectEqualsOperation();

            Console.WriteLine("类对象的Equals");
            _objectEquals();
            Console.WriteLine("\r\n*****对于 string 类型，== 比较字符串的值");

            Console.WriteLine("----_objectEquals");
            _boxingEquals();
            Console.ReadLine();

        }

        private static void _valueEqualsMethod()
        {
            int i1 = 1;
            int i2 = 1;
            Console.WriteLine("Equals是int的方法");
            Console.WriteLine("i1.Equals(i2): " + i1.Equals(i2));
            Console.WriteLine("i1.GetHashCode:" + i1.GetHashCode().ToString());
            Console.WriteLine("i2.GetHashCode:" + i2.GetHashCode().ToString());
        }

        private static void _valueEqualsOperation()
        {
            int i1 = 1;
            int i2 = 1;
            Console.WriteLine("== 是操作符");
            Console.WriteLine("i1 == i2: " + ( i1 == i2));
            Console.WriteLine("i1.GetHashCode:" + i1.GetHashCode().ToString());
            Console.WriteLine("i2.GetHashCode:" + i2.GetHashCode().ToString());
        }

        private static void _objectEqualsMethod()
        {
            object o1 = new object();
            object o2 = new object();
            Console.WriteLine("Equals是Object的方法");
            Console.WriteLine("o1.Equals(o2): " + o1.Equals(o2));
            Console.WriteLine("o1.GetHashCode:" + o1.GetHashCode().ToString());
            Console.WriteLine("o2.GetHashCode:" + o2.GetHashCode().ToString());
        }

        private static void _objectEqualsOperation()
        {
            object o1 = new object();
            object o2 = new object();
            Console.WriteLine("== 是操作符");
            Console.WriteLine("o1 == o2: " + (o1 == o2));
            Console.WriteLine("o1.GetHashCode:" + o1.GetHashCode().ToString());
            Console.WriteLine("o2.GetHashCode:" + o2.GetHashCode().ToString());
        }

        private class _Person
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public _Person(string name)
            {
                this.name = name;
            }
        }

        private static void _objectEquals()
        {
            Polymorphism.RealWorldStringIssue();

            _Person p1 = new _Person("jia");
            _Person p2 = new _Person("jia");
            Console.WriteLine(p1 == p2);        //Flase
            Console.WriteLine(p1.Equals(p2));   //False


            _Person p3 = new _Person("jia");
            _Person p4 = p3;
            Console.WriteLine(p3 == p4);        //True
            Console.WriteLine(p3.Equals(p4));   //True

            
            
        }

        private static void _boxingEquals() //int装箱后的对比
        {
            object objA = 1;
            object objB = 1;
            Console.WriteLine(objA.Equals(objB));        //True
            Console.WriteLine(objA == objB);             //Flase
            Console.WriteLine(object.ReferenceEquals(objA, objB)); //False
        }


    }

    
}
