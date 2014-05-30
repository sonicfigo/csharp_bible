using System;

namespace Bible.EqualsDir
{
    public class Guy
    {
        
        private readonly string name;

       
        public string Name { get { return name; } }

        
        private readonly int age;

        
        public int Age { get { return age; } }

        
        public int Cash { get; private set; }

        
        public Guy(string name, int age, int cash)
        {
            this.name = name;
            this.age = age;
            Cash = cash;
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} years old and has {2} bucks", Name, Age, Cash);
        }

        
        public int GiveCash(int amount)
        {
            if (amount <= Cash && amount > 0)
            {
                Cash -= amount;
                return amount;
            }
            else
            {
                return 0;
            }
        }

        
        public int ReceiveCash(int amount)
        {
            if (amount > 0)
            {
                if (amount > 0)
                {
                    Cash += amount;
                    return amount;
                }
                Console.WriteLine("{0} says: {1} isn't an amount I'll take", Name, amount);
            }
            return 0;
        }
    }

    
}
