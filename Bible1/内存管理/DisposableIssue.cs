using System;

namespace Bible.内存管理
{
    //托管与非托管的资源释放
    public class DisposableIssue 
    {
        private class _Foo : IDisposable
        {

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

    }
}
