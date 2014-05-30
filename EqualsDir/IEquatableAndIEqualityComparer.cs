using System;
using System.Collections.Generic;

namespace Bible.EqualsDir
{
    //何时使用 IEquatable<T> 和 IEqualityComparer<T>
    public class IEquatableAndIEqualityComparer
    {
        private class _Foo : IEquatable<_Foo>
        {

            public bool Equals(_Foo other)
            {
                throw new NotImplementedException();
            }
        }

        private class _Bar : IEqualityComparer<_Bar>
        {

            public bool Equals(_Bar x, _Bar y)
            {
                throw new NotImplementedException();
            }

            public int GetHashCode(_Bar obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}
