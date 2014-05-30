using System;

namespace Bible.内存管理
{
    //可参考文章 
    //http://www.c-sharpcorner.com/UploadFile/rmcochran/csharp_memory01122006130034PM/csharp_memory.aspx
    //翻译: http://www.360doc.com/content/11/0503/17/6075898_114102233.shtml

    //新 http://stackoverflow.com/questions/79923/what-and-where-are-the-stack-and-heap
    /*值类型在 Stack栈 中分配内存（除非该值对象是属于某个类的实例，那么在heap中），包括：
     *  bool
     *  sbyte byte 
     *  short ushort int uint long ulong
     *  char 
     *  float double decimal
     *  enum struct
     *  pointer引用类型的指针
     * 
     * 线程：
     * 每个线程都有自己的Stack
     * 所有多线程共享一个Heap
     * 
     * 位置：
     * 当值类型数据在方法体中被声明时，都是放置在stack上的。
     * 当值类型存在于一个引用类型中，那么将放在Heap中。
     * 数组的元素，不管是引用类型还是值类型，都存储在Heap上。
     * 
     * 父类
     *  值类型都派生自System.ValueType,
     *  所有的值类型都是密封（seal）的，所以无法派生出新的值类型,
     *  不能是Null，除非使用 i?=null;
     *  引用类型都派生自System.Object
     * 
     *  值类型在内存管理方面具有更好的效率
     *  
        
     * 
     * 
     * 引用类型在 Heap堆 中分配内存，包括：
     * class, interface
     * delegate
     * object
     * string
     * Array
     * 
     * 
     * 
     */
    public class StackHeap
    {
        public static void Run()
        {
            IsValueType();
            Console.WriteLine();
            StackHeap.DefaultConstructor();
            Console.WriteLine();
            StackHeap.StackHascode();
        }

        public static void IsValueType()
        {
            //System.ValueType本身是一个类类型，而不是值类 型。
            //其关键在于ValueType重写了Equals()方法，从而对值类型按照实例的值来比较，而不是引用地址来比较
            Console.WriteLine("ValueType is value Type:" + typeof(ValueType).IsValueType);

            Console.WriteLine("bool is value Type:" + typeof (bool).IsValueType);

            Console.WriteLine("Array is value Type:" + typeof(Array).IsValueType);
        }

        public static void DefaultConstructor()
        {
            int i = 0;
            //相当于
            int j = new int();
            Console.WriteLine("int i 's hashcode " + i.GetHashCode());
            Console.WriteLine("int j 's hashcode " + j.GetHashCode());
        }

        public static void StackHascode()
        {
            int i1 = 1;
            Console.WriteLine("int 1 's hashcode "+i1.GetHashCode());
            Object i1Obj = i1;
            Console.WriteLine("object 1 's hashcode " + i1Obj.GetHashCode());

            int i2 = 2;
            Console.WriteLine("int 2 's hashcode "+ i2.GetHashCode());
        }
    }

    

   


}
