using System;

namespace Bible.内存管理
{
    //值类型 和 引用类型 传参时
    //参数占用的 stack 和heap 大小
    //值类型会进行 复制值副本，若参数是如大Struct是，将会占用大量stack空间
    //引用类型只会 复制引用类型的指针， 占用较小

    //结论：
    //使用struct，若包含的数值量较大，注意传参时的内存占用影响
    //引用类型没有这类问题，只会每次自增一个4Bytes的指针副本
    //若是ref的，则是指针合并
    public static class ParameterIssueSize
    {
        private static uint _count1 = 0;
        private static uint _count2 = 0;

        public static void Run()
        {
            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _testFunSize();

            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _intSize();
            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _longSize();
            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _structSize();
            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _classSize();
            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _stringIsPrimativeType();

            Printer.Print("\r\n有参数时，会进行值类型的参数Copy===========");
            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _intSizeX(1); //若用int jj = 1; 再调用_intSizeX(jj) ，stack消耗情况一致
            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _longSizeX(1);
            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _structSizeX(new _BigStruct());
            _BigStruct bs = new _BigStruct();
            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _structSizeXref(ref bs);

            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _classSizeX(new object());
            object x = new object();
            _count1 = StackUtil.EstimatedRemainingStackBytes();
            _classSizeXref(ref x);

            _count1 = StackUtil.EstimatedRemainingStackBytes();
            Printer.Print("\r\n空方法的占用，若测试，将会递归造成oom===========");
           // _empty();
        }

        private static void _testFunSize()//每个内嵌_print()的占用size
        {
            Console.WriteLine("两个function + 1 variable 在Stack里占用的Bytes");
            _printFuncSize();
        }

        #region 无参数 Case

        public static void _intSize() //@2.此方法体 + 内嵌_print() 消耗132 ，那么每个方法的执行指令是占用64
        {
            Int32 i1 = 1; //无论是 x86还是 x64， int32 都是 4 Bytes
            Console.WriteLine("一个 int 在Stack里占用的Bytes");
            _print();
        }

        public static void _longSize()
        {
            long i = 0;
            Console.WriteLine("一个 long 在Stack里占用的Bytes");
            _print();
        }

        private static void _structSize()
        {
            _BigStruct bs = new _BigStruct();
            Console.WriteLine("一个 _BigStruct 在Stack里占用的Bytes");
            _print();
        }

        private static void _classSize()
        {
            //Class a = new Class();
            //1） Class a 的时候， 生成一个空的引用指针，并把他压栈到堆栈中。
            //2）new Class() 生成一个类的实例， 并且在堆上分配对应内存。
            //3 ) = 赋值的时候， a的引用指向新生成的实例。
            _FooClass foo1 = new _FooClass(); //4 + 4
            Console.WriteLine("一个 _FooClass 的引用指针 在Stack里占用的Bytes ");
            _print();
        }

        private static void _stringIsPrimativeType()
        {
            //int i;
            //Console.WriteLine("一个 String 在Stack里占用的Bytes");
            //_print();
        }

        #endregion

        #region 有参数 Case
        public static void _intSizeX(int x)
        {
            int y = 0;
            Console.WriteLine("有参时，两个 int 在Stack里占用的Bytes");
            _print();
        }

        public static void _longSizeX(long x)
        {
            long i = 0;
            Console.WriteLine("有参时，两个  long 在Stack里占用的Bytes");
            _print();
        }

        private static void _structSizeX(_BigStruct x)
        {
            _BigStruct bs = new _BigStruct();
            Console.WriteLine("有参时，两个 _BigStruct 在Stack里占用的Bytes");
            _print();
        }

        private static void _structSizeXref(ref _BigStruct x)
        {
            _BigStruct bs = new _BigStruct();
            Console.WriteLine("有ref参时，1个 _BigStruct-80 + 1个指针-4 在Stack里占用的Bytes");
            _print();
        }

        private static void _classSizeX(object x)
        {
            Console.WriteLine("有参数时，x是指针副本 在Stack里占用的Bytes");
            _print();
        }

        private static void _classSizeXref(ref object y)
        {
            Console.WriteLine("有ref参数时，y是指针副本 在Stack里占用的Bytes");
            _print();
        }
        #endregion

        private static void _empty()
        {
            _print();
            _count1 = StackUtil.EstimatedRemainingStackBytes();
            Console.WriteLine("递归函数，不会增加函数指针占用，只会每次增加内部_count1 的4Bytes 占用");
            _empty();
        }

        private class _FooClass
        {
        }
        private struct _BigStruct
        {
            private long a, b, c, d, e, f, g, h, i, j;// 10个long = 10*8 Bytes
        }

        public static void _printFuncSize()
        {
            _count2 = StackUtil.EstimatedRemainingStackBytes(); //占用4
            Console.WriteLine(_count1 - _count2);//此处的差值就是 两个function+1个_count2消耗的stack size
        }

        public static void _print() //@1.本方法执行指令64 + 内部参数1个_count2副本4 ， 固定消耗 68 Bytes
        {
            _count2 = StackUtil.EstimatedRemainingStackBytes(); //占用4
            Console.WriteLine(_count1 - _count2 -132);
            //减去两层函数的 132（调用者64 + 本68） Bytes 消耗，就是实际每个函数体内的Stack消耗
        }
    }
}
