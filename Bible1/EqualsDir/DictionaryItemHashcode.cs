using System.Collections.Generic;

namespace Bible.EqualsDir
{
    /* 为何重写Equals时，Warning提示也要重写GetHashcode
     * 
     * 一些原则：
     * 1.两个对象Equals，则通过GetHashCode()得到的值必须相同。
     * 对象做为Key值，必须对应一个Value对象，如果得到的值不同，则会出现一个Key对应多个Value对象的情况，这违背了Key的原始意义，不过如果你非要违背这个原则，在HashTable的语法中也是没有任何问题的（这个在后面会举例论述）只不过违背了Key的语意。
     * 2.通过GetHashCode（）得到的值必须是恒定不变的。
     * 这个很明显，如果在存储以后这个值可以随意变动，在通过Key取Value的时候就会有问题，在语法上会报经典的“未将对象引用设置到对象实例”。
     * 3.通过GetHashCode（）得到的值必须在整数的取值范围内是均匀分布的
     * 这样做的目的是提高HashTable的查找效率。
     * 
     * 如果两个object 的 Equals相等， 那么GetHashcode一定要返回同样的值, 否则会影响到Dictionary 的使用
     * 如果 GetHashcode 相等 ，Equals 不一定相等
     * 
     * http://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden
     */

    public class DictionaryItemHashcode
    {
        public static void Run()
        {
            _same_hashcode_but_false_equals();
            Printer.Print("");
            _dictionary_compare_failed();
            Printer.Print("");
            _dictionary_compare_success();
        }

        private static void _same_hashcode_but_false_equals() //如果 GetHashcode 相等 ，Equals 不一定相等
        {
            // -3 -2 -1 0 1 2 3
            long l1 = -3;
            long l2 = 2;
            Printer.Print("-3的hashcode " + l1.GetHashCode().ToString());
            Printer.Print("2的hashcode "+ l2.GetHashCode().ToString());
            Printer.Print("-3 == 2 " + (l1 == l2).ToString());
        }

        #region Dict 查找失败
        private static void _dictionary_compare_failed()
        {
            Dictionary<_Foo, long> incomeDict = new Dictionary<_Foo, long>();
            _Foo foo1 = new _Foo(1, "mark1");
            _Foo foo2 = new _Foo(2, "jordon1");
            incomeDict.Add(foo1, 1000);
            incomeDict.Add(foo2, 500);

            _Foo foo1Clone = new _Foo(1, "mark1");

           bool b = incomeDict.ContainsKey(foo1Clone);

           Printer.Print("未重写gethashcode ,mark1的工资是否找到 " + b.ToString());
        }

        private class _Foo
        {
            public readonly int Id;
            public readonly string Name;

            public _Foo(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is _Foo))
                    return false;
                else
                {
                    _Foo target = (_Foo)obj;
                    return this.Id == target.Id;
                }
            }
        }
        #endregion

        #region Dict 查找成功
        private static void _dictionary_compare_success()
        {
            Dictionary<_Bar, long> incomeDict = new Dictionary<_Bar, long>();
            _Bar bar1 = new _Bar(1, "susan");
            _Bar bar2 = new _Bar(2, "bree");
            incomeDict.Add(bar1, 1000); //若重写了GetHashcode， 此处会调用
            incomeDict.Add(bar2, 500);
            _Bar bar1Clone = new _Bar(1, "susan");
            bool b = incomeDict.ContainsKey(bar1Clone);
            Printer.Print("重写gethashcode ,susan的工资是否找到 " + b.ToString());

            long _match = incomeDict[bar1Clone];
            Printer.Print("工资是" + _match);
        }

        private class _Bar
        {
            public readonly int Id;
            public readonly string Name;

            public _Bar(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is _Bar))
                    return false;
                else
                {
                    _Bar target = (_Bar)obj;
                    return this.Id == target.Id;
                }
            }

            public override int GetHashCode()
            {
                return this.Id.GetHashCode();
            }
        }

        #endregion
    }
}
