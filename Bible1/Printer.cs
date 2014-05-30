using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bible
{
    public static class Printer
    {
        public static void Print(string s, params object[] args)
        {
            Console.WriteLine(string.Format(s, args));
        }
    }
}
