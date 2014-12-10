using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Bible1Lib;

namespace Bible1Lib
{


    public static class FooController
    {
        public static void Run()
        {
            Assembly currentAssembly = Assembly.LoadFrom("Bible1Lib.dll");
            var typesWithTxAttr = from type in currentAssembly.GetTypes()
                        where Attribute.IsDefined(type, typeof(TxAttribute))
                        select type;
            foreach (var clsType in typesWithTxAttr)
            {
                Console.WriteLine(clsType.FullName);
                object[]  txAtts =clsType.GetCustomAttributes(typeof (TxAttribute), false);
                foreach (var tx in txAtts)
                {
                    TxAttribute txAttr = tx as TxAttribute;
                    if (txAttr != null)
                    {
                        Console.WriteLine("DbName:      "+txAttr.DbName);

                        Console.WriteLine("");

                        var v1 = Activator.CreateInstance(clsType);
                        Console.WriteLine(v1);

                        //IFooContext v2 = (IFooContext)v1;
                        //var v3 = Convert.ChangeType(v1, typeof(IFooContext));
                        //Console.WriteLine(v2);
                        //Console.WriteLine(v3);
                        //Activator.CreateInstance()

                        IFooContext var1 = new FooContext();
                    }
                }
            }
        }

    }


}
