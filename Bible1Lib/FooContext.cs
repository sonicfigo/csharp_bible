using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible1Lib
{
    

    public interface IFooContext
    {
    }
    public interface IFooRepository
    {
    }



    [Tx("xhfoc")]
    public class FooContext : IFooContext
    {
        public IFooRepository FooRepo;
    }

    public class FooRepository : IFooRepository
    {

    }
}
