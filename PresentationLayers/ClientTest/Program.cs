using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Infrastructure;
using NexusCore.Core.Adapter.IoC;
using NexusCore.Data.Infrastructure;

namespace ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EngineContext.Instance.DiContainerInitialize(new AutofacFactory(
                builder =>
                {
                    // Unit of Work
                    builder.RegisterType<ContentContext>().As<IContentContext>().InstancePerLifetimeScope();
                    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();                    
                },
                new AutofacRegisterAdmin(),
                container => { }));

            var itemTypeModel = new GetItemTypeModel();
            //var install = new Installation();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
