using NUnit.Framework;

namespace Bible.内存管理
{
    /* 2014年4月6日00:11:45 done
     * 
     * 值类型、引用类型的传参区别
     * 结论：
     * 1.值副本 和 指针副本的区别
     * 2.引用类型 的ref 使用区别,体现在 指针副本改变指向时
     * */
    public static class ParameterIssue1
    {
        public static void Run()
        {
            _go1();             //1. _go1被放置到栈顶 ( 只包含需要执行的逻辑字节，即执行该方法的指令，而非方法体内的数据）
                                //5. _addFive()执行完成后，从栈顶依次将 y 和 _addFive()去掉
            _go1ref();

            _go2();             //@1. _go2被放置到栈顶
            _go2Null();

            _go2ref();
            _go2refNull();
        }

        #region 值类型
        private static void _go1()
        {
            int x = 1;          //2. x的值1 入栈顶
            _addFive1(x);        //3. _addFive1()入栈顶
            Assert.AreEqual(1, x);
            Printer.Print("x = {0} 值类型的传参，只是copy了x的副本，并入栈到栈顶，未改变x原值.", x);
            Printer.Print("由于是copy副本，所以注意若是大量的struct传参，将会占用大量内存，可使用ref指定");
        }

        private static int _addFive1(int y) //4.y 入栈顶，且是 值x的 !!!值副本（x=1）!!!
        {
            y += 5;
            Printer.Print("y = {0} 自增了5，作为值对象x的副本，不影响x.", y);
            return y;
        }
        #endregion

        #region 值类型的ref传参

        private static void _go1ref()
        {
            int x = 1;
            _addFive1ref(ref x);
            Assert.AreEqual(6, x);
            Printer.Print("x = {0}", x);
        }

        private static void _addFive1ref(ref int y)
        {
            y += 5;
        }
        #endregion


        #region 引用类型
        private class _Flight
        {
            public int Id { get; set; }
        }

        private static void _go2()
        {
            _Flight x = new _Flight(); //@2.一个Flight(及它的Id)入堆， x作为指针入栈顶 
            x.Id = 1;
            _addFive2(x); //@3. _addFive2() 入栈顶
            Assert.AreEqual(6, x.Id);
            Printer.Print("x.Id = {0} 引用类型的传参，导致栈上的x和y指针，同时指向堆上的Flight，y的修改直接体现到x上.", x.Id);
        }

        private static void _addFive2(_Flight y) //@4.y 入栈顶，且是指针x的 !!!指针副本!!!
        {
            y.Id += 5;
            Printer.Print("y.Id = {0} 自增了5，作为指针x的副本，影响了x指针指向的Flight.", y.Id);
        }



        #endregion

        #region 引用类型+改变指针指向

        private static void _go2Null()
        {
            _Flight x = new _Flight();
            x.Id = 1;
            _addFive2Null(x);
            Assert.AreEqual(6, x.Id);
            
        }

        private static void _addFive2Null(_Flight y)
        {
            y.Id += 5;
            y = null;
            Printer.Print("y与x是分离的副本，y指向null后，x不受影响");
        }
        #endregion

        #region 引用类型的ref传参
        private static void _go2ref()
        {
            _Flight x = new _Flight();
            x.Id = 1;
            _addFive2ref(ref x);
            Assert.AreEqual(6, x.Id);
            Printer.Print("x.Id = {0}", x.Id);
        }

        private static void _addFive2ref(ref _Flight y) //最终效果与不ref一样为6，但区别在于：y 也入栈顶，但却不再指向Flight，而是直接与指针x绑定一起
        {
            y.Id += 5;
        }
        #endregion

        #region 引用类型的ref传参+改变指针指向
        private static void _go2refNull()
        {
            _Flight x = new _Flight();
            x.Id = 1;
            _addFive2refNull(ref x);
            Assert.IsNull(x);
            Printer.Print("x == null {0}", x == null);
        }

        private static void _addFive2refNull(ref _Flight y) //同上：y 也入栈顶，但却不再指向Flight，而是直接指向指针x，与x指针合并
        {
            y = null;
            Printer.Print("y与x两个指针的绑定，导致y指向null后，x也为null");
        }
        #endregion

    }
}
