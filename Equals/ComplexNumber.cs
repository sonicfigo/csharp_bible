using System;

namespace Bible.Equals
{
    public static class CompareComplexNumbers
    {
        public static void Run()
        {
            ComplexNumber a = new ComplexNumber() { Real = 4.5D, Imaginary = 8.4D };
            ComplexNumber b = new ComplexNumber() { Real = 6.3D, Imaginary = -2.3D };
            ComplexNumber c = new ComplexNumber() { Real = 4.5D, Imaginary = 8.4D };

            Console.WriteLine("{0} equals {1}: {2}",
                a, b, _compareTwoComplexNumbers(a, b));
            Console.WriteLine("{0} equals {1}: {2}",
                b, c, _compareTwoComplexNumbers(b, c));
            Console.WriteLine("{0} equals {1}: {2}",
                a, c, _compareTwoComplexNumbers(a, c));
        }

        private static bool _compareTwoComplexNumbers(ComplexNumber a, ComplexNumber b)
        {
            // This returns true only if the real parts and the imaginary parts are equal
            return ((a.Real == b.Real) && (a.Imaginary == b.Imaginary));
        }

        private class ComplexNumber
        {
            public double Real { get; set; }
            public double Imaginary { get; set; }

            public override string ToString()
            {
                return String.Format("{0}{1}{2}i",
                    Real,
                    Imaginary >= 0 ? "+" : "-",
                    Math.Abs(Imaginary));
            }
        }
    }
}
