using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Bible.克隆
{
    //在通常情况下，我们应该"克隆"引用类型，"拷贝"值类型。

    /*
     * 引用类型应该使用 ‘Clone’ ，可以通过实现 ICloneable 来做到。
     * 
     * 具体实现可分浅表克隆 和 深度克隆
     * 
     * MemberwiseClone 浅表克隆
     * 两个Employee 是不同实例，但引用同一个浅表克隆的Address，即Employee下的引用类型，只复制指针。

     * 深度克隆自行实现，用stream可方便实现
     */

    public static class CloneIssue
    {
        
        public static void Run()
        {
            _cloneByMemberwise();

            _cloneByStream();
        }

       

        public static void _cloneByMemberwise()
        {
            _Employee employee1 = new _Employee("A", 1, new Address("厦门"));
            _Employee clone1 = (_Employee)employee1.Clone();

            Console.WriteLine("\r\nMemberwise");
            Console.WriteLine(Object.Equals(employee1, clone1));            //False
            Console.WriteLine(Object.ReferenceEquals(employee1, clone1));   //False
            Console.WriteLine(employee1 == clone1);                         //False

            Console.WriteLine(Object.Equals(employee1.Addr, clone1.Addr));          //True
            Console.WriteLine(Object.ReferenceEquals(employee1.Addr, clone1.Addr)); //True
            Console.WriteLine(employee1.Addr == clone1.Addr);                       //True
        }

        private static void _cloneByStream()
        {
            _Employee employee1 = new _Employee("B", 1, new Address("福州"));
            _Employee clone1 = (_Employee)employee1.DeepClone();

            Console.WriteLine("\r\nDeep");
            Console.WriteLine(Object.Equals(employee1, clone1));            //False
            Console.WriteLine(Object.ReferenceEquals(employee1, clone1));   //False
            Console.WriteLine(employee1 == clone1);                         //False

            Console.WriteLine(Object.Equals(employee1.Addr, clone1.Addr));          //False
            Console.WriteLine(Object.ReferenceEquals(employee1.Addr, clone1.Addr)); //False
            Console.WriteLine(employee1.Addr == clone1.Addr);                       //False
        }

        [Serializable] //深度克隆必须
        public class _Employee : ICloneable
        {
            public readonly string Name;
            public readonly long ID;
            public readonly Address Addr;
            public _Employee(string name, long id, Address addr)
            {
                Name = name;
                ID = id;
                Addr = addr;
            }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            public object DeepClone()
            {
                MemoryStream stream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return formatter.Deserialize(stream) as _Employee;
            }
        }

        [Serializable]
        public class Address
        {
            public readonly string AddressText;
            public Address(string text)
            {
                AddressText = text;
            }
        }

    }
}
