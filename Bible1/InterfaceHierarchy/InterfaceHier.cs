using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible1.InterfaceHierarchy
{
    public interface XEnumerable
    {
        IEnumerator GetEnumerator();
    }

    public interface XEnumerable<out T> : XEnumerable
    {
        IEnumerator<T> GetEnumerator();
    }


    public interface XCollection : XEnumerable
    {
        int Count { get; }
        bool IsSynchronized { get; }
        Object SyncRoot { get; }

        void CopyTo(Array array, int index);
    }


    public interface XCollection<T> : XEnumerable<T>, XEnumerable //多余的声明 XEnumerable（resharper提示）
    {

    }

    public class Abc<T> : XCollection<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator XEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
