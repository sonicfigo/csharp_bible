using System;
using System.Runtime.InteropServices;

/*
 * 说明String的对比，内存放置位置。
 */
namespace Bible.字符串
{
    //String的四种比较字符串的方法、效率
    //String的地址管理
    /*
     * 结论:
     * 三种比较都能正确对比内容
     * 1.CompareTo 会使用CultureInfo
     * 2.Equals 不会使用CultureInfo
     * 3.==与Equals等同
     * 
     * 最后一种object.ReferenceEquals对比的是地址，无法正确对比文本内容
     * 
     * 参考 http://stackoverflow.com/questions/44288/differences-in-string-compare-methods-in-c-sharp
     * 
     * ps:java中字符串内容比较必须用equals
     */
    public class StringCompare
    {
        public static void Run()
        {
            Console.WriteLine("-------------1");
            StringCompare._operator1();
            Console.WriteLine("-------------2");
            StringCompare._operator2();
            Console.WriteLine("-------------3");
            StringCompare._operator3();
            Console.WriteLine("-------------4");
            StringCompare._operator4();
            Console.WriteLine("-------------5");
            StringCompare._operator5();
            Console.WriteLine("-------------6");
            StringCompare._operator6();
            Console.WriteLine("\r\n-------------Performance");
            _performanceCounter();
            Console.ReadLine();
        }

        private static void _operator1()
        {
            string a = "okl";
            string b = "ok" + "l";
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a.CompareTo(b));
            Console.WriteLine(a == b);
            Console.WriteLine("object reference equal:" + object.ReferenceEquals(a, b));//True 
        }

        private static void _operator2()
        {
            string a = "okl";
            string b = "ok";
            b = b + "l"; //产生了不同于纯字符串'okl'的新的对象
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a.CompareTo(b));
            Console.WriteLine(a == b);
            Console.WriteLine("object reference equal:" + object.ReferenceEquals(a, b));//False
        }

        private static void _operator3()
        {
            char[] aTemp = {'o', 'k', 'l'};
            string a = new string(aTemp);
            string a2 = new string(aTemp);
            Console.WriteLine(a.Equals(a2));
            Console.WriteLine(a.CompareTo(a2));
            Console.WriteLine(a == a2);
            Console.WriteLine("object reference equal:" + object.ReferenceEquals(a, a2));//False
        }

        private static void _operator4()
        {
            char[] aTemp = { 'o', 'k', 'l' };
            string original = "okl";
            string a2 = new string(aTemp);
            Console.WriteLine(original.Equals(a2));
            Console.WriteLine(original.CompareTo(a2));
            Console.WriteLine(original == a2);
            Console.WriteLine("object reference equal:" + object.ReferenceEquals(original, a2));//False
        }

        private static void _operator5()
        {
            char[] aTemp = {'o', 'k', 'l'};
            string a = new string(aTemp);
            string b = "okl";
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a.CompareTo(b));
            Console.WriteLine(a == b);
            Console.WriteLine("object reference equal:" + object.ReferenceEquals(a, b));//False
        }

        private static void _operator6()
        {
            string a = "123";
            string b = null;
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a.CompareTo(b));
            Console.WriteLine(a == b);
            Console.WriteLine("object reference equal:" + object.ReferenceEquals(a, b));//False
        }


        private static void _performanceCounter()
        {
            string str1 = "abcdef";
            string str2 = "abc";
            str2 = str2 + "def";
            PerFormanceCounter p = new PerFormanceCounter();
            

            p.Reset();
            Console.WriteLine(string.Equals(str1, str2));
            p.Stop();
            Console.WriteLine("Equals   :" + p.ElapsedSeconds * 1000);

            p.Reset();
            Console.WriteLine(str1.CompareTo(str2));
            p.Stop();
            Console.WriteLine("CompareTo:" + p.ElapsedSeconds * 1000);

            p.Reset();
            Console.WriteLine(str1 == str2);
            p.Stop();
            Console.WriteLine("==       :" + p.ElapsedSeconds * 1000);

            p.Reset();
            Console.WriteLine(object.ReferenceEquals(str1, str2));
            p.Stop();
            Console.WriteLine("ReferenceEquals:" + p.ElapsedSeconds * 1000);
        }

        public class PerFormanceCounter
        {
            [DllImport("kernel32.dll")]
            extern static short QueryPerformanceCounter(ref long x);
            [DllImport("kernel32.dll")]
            extern static short QueryPerformanceFrequency(ref long x);

            private long frequency;
            private long start, end;

            public PerFormanceCounter()
            {
                QueryPerformanceFrequency(ref frequency);
            }

            public void Reset() { QueryPerformanceCounter(ref start); }

            public void Stop() { QueryPerformanceCounter(ref end); }

            public double ElapsedSeconds
            {
                get
                {
                    return (end - start) * 1.0 / frequency;
                }
            }
            public long Frequency
            {
                get
                {
                    return frequency;
                }
            }
        }
    }



}
