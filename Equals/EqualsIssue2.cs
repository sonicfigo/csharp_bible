using System;
using NUnit.Framework;

namespace Bible.Equals
{
    
    /*
     * Object.Equals方法什么时候被调用到
     * override Equals
     */
    public static class EqualsIssue2
    {
        #region 私有类
        private class _NormalClass
        {
            public readonly long Id;

            public _NormalClass(long id)
            {
                Id = id;
            }
        }

        private class _OverrideClass
        {
            public readonly int Id;

            public _OverrideClass(int id)
            {
                Id = id;
            }
            public override bool Equals(object other)
            {
                Console.WriteLine("override Equals has been called.");
                return this.Id == ((_OverrideClass)other).Id;
            }
        }

        #endregion

        public static void Run()
        {
            _two_normal_class_with_samevalue();
            _two_override_class_with_samevalue();
        }

        private static void _two_normal_class_with_samevalue()
        {
            var normalA = new _NormalClass(1);
            var normalB = new _NormalClass(1);
            Console.WriteLine("==:  "+(normalA == normalB));             //False
            Console.WriteLine("Equals:"+(normalA.Equals(normalB)));        //False
        }

        private static void _two_override_class_with_samevalue()
        {
            var overrideA = new _OverrideClass(1);
            var overrideB = new _OverrideClass(1);

            Console.WriteLine("object.Equals(A, B):  " + object.Equals(overrideA, overrideB)); //true 调用 Equals 的重写
            Console.WriteLine("A.Equals(B):  " + overrideA.Equals(overrideB)); //true 调用 Equals 的重写
            Assert.AreEqual(overrideA, overrideB); //true 调用 Equals 的重写

            Console.WriteLine();
            Console.WriteLine("==:  " + (overrideA == overrideB)); //false 纯粹对比内存地址

            Console.WriteLine(overrideA.GetHashCode().GetHashCode());
            Console.WriteLine(overrideB.GetHashCode().GetHashCode());
        }
    }
}
