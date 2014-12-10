using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible1.Ev
{
    /*原始写法*/
    public class People
    {
        public enum Language
        {
            English, Chinese
        }

        public void GreetPeople(string name, Language lang)
        {
            switch (lang)
            {
                case Language.English:
                    EnglishGreeting(name);
                    break;
                case Language.Chinese:
                    ChineseGreeting(name);
                    break;
            }
        }
        public void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }
        public void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }
    }


}
