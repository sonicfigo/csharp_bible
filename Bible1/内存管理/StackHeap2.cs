namespace Bible.内存管理
{
    public struct ValueTypeStruct
    {
        private object obj1;
        public void Method()
        {
            obj1 = new object();
            object local1 = new object();
        }
    }

    public class ReferenceTypeClass
    {
        private int _valueTypeField; //跟随Class，在堆上
        public ReferenceTypeClass()
        {
            _valueTypeField = 0;
        }
        public void Method()
        {
            int valueTypeLocalVariable = 0; //局部变量，在栈上
        }
    }

    public class StackHeap2
    {
        public static void ValueTypeRun()
        {
            ValueTypeStruct struct1 = new ValueTypeStruct();
            struct1.Method();
            //obj1 和 local1 都在哪存放?
            //单看 struct1，这是一个结构体实例，感觉似乎是整块都在栈上。
            //但是字段obj1是引用类型，局部变量 local1 也是引用类型。
        }

        public static void ValueTypeRun2()
        {
            ReferenceTypeClass referenceTypeClassInstance = new ReferenceTypeClass();
            // _valueTypeField在哪存放?
            referenceTypeClassInstance.Method();
            // valueTypeLocalVariable在哪存放?

            //referenceTypeClassInstance 也有同样的问题，
            //referenceTypeClassInstance 本身是引用类型，似乎应该整块部署在托管堆上。
            //但字段 _valueTypeField是值类型，局部变量valueTypeLocalVariable也是值类型，它们究竟是在栈上还是在托管堆上？
            
            //对上面的情况正确的分析是：
            //1.引用类型在栈中存储一个引用，其实际的存储位置位于托管堆。
            //  为了方便，简称引用类型部署在托管堆上。
            //2.值类型总是分配在它声明的地方，作为字段时，跟随其所属的变量（实例）存储；作为局部变量时，存储在栈上。
        }

        //辨明值类型和引用类型的使用场合。
        public static void WhatHappen()
        {
            //在C#中，我们用struct/class来声明一个类型为值类型/引用类型。考虑下面的例子：
            //SomeType[] oneTypes = new SomeType[100];

            //如 果SomeType是值类型，则只需要一次分配，大小为SomeType的100倍。
            
            /*而如果SomeType是引用类型
             * 刚开始需要100次分配，分配后 数组的各元素值为null
             * 然后再初始化100个元素，结果总共需要进行101次分配。
             * 
             * 这将消耗更多的时间，造成更多的内存碎片。所以，如果类型的职责主 要是存储数据，值类型比较合适。
             * 一般来说，值类型（不支持多态）适合存储供 C#应用程序操作的数据
             * 
             * 而引用类型（支持多态）应该用于定义应用程序的行为。
             * 
             * 通常我们创建的引用类型总是多于值类型。如果满足下面情况，那么我们就应该创建为值类型：
             * 该类型的主要职责用于数据存储。 
             * 该类型的共有接口完全由一些数据成员存取属性定义。 
             * 该类型永远不可能有子类。 
             * 该类型不具有多态行为。
             */
        }

    }


    
}
