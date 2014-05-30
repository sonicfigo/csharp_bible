using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bible.EqualsDir
{
    /// <summary>
    /// A guy that knows how to compare itself with other guys
    /// </summary>
    public class EquatableGuy : Guy, IEquatable<Guy>
    {
        public EquatableGuy(string name, int age, int cash)
            : base(name, age, cash) { }

        /*
         * The Equals() method compares the actual values in the other Guy object's
         * fields, checking his Name, Age, and Cash to see if they're the same and only
         * returning true if they are.
         */

        /// <summary>
        /// Compare this object against another EquatableGuy
        /// </summary>
        /// <param name="other">The EquatableGuy object to compare with</param>
        /// <returns>True if the objects have the same values, false otherwise</returns>
        public bool Equals(Guy other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name) && other.Age == Age && other.Cash == Cash;
        }

        /// <summary>
        /// Override the Equals method and have it call Equals(Guy)
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        /// <returns>True if the value of the other object is equal to this one</returns>
        public override bool Equals(object obj)
        {
            // Since our other Equals() method already compares guys, we'll just call it.
            if (!(obj is Guy)) return false;
            return Equals((Guy)obj);
        }

        /* 
         * We're also overriding the Equals() method that we inherited from Object, as 
         * well as GetHashCode (because of the contract mentioned in that MSDN article).
         */

        /// <summary>
        /// Part of the contract for overriding Equals is that you need to override
        /// GetHashCode() as well. It should compare the values and return true
        /// if the values are equal.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // This is a pretty standard pattern for GetHashCode(). Note the use
            // of the bitwise XOR (^) operator, a prime number, and the conditional
            // operator (?:). I used ?: to handle nulls in GetHashCode&mdash;if the
            // property is null, it XORs the result with zero, which just means it doesn't
            // change the result at all.
            const int prime = 397;
            int result = Age;
            result = (result * prime) ^ (Name != null ? Name.GetHashCode() : 0);
            result = (result * prime) ^ Cash;
            return result;
        }
    }
}
