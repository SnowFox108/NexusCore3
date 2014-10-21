using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Infrastructure;
using NexusCore.Core.Adapter.IoC;

namespace ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EngineContext.Instance.DiContainerInitialize(new AutofacFactory(
                builder =>
                {
                    
                },
                new AutofacRegisterAdmin(),
                container => { }));

            //var itemTypeModel = new GetItemTypeModel();
            var install = new Installation();
            Console.ReadKey();
        }
    }
}
