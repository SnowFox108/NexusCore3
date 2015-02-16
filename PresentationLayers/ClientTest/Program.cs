using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Infrastructure;
using NexusCore.Core.Adapter.IoC;
using NexusCore.Data.Infrastructure;
using NexusCore.Infrasructure.Adapter.ErrorHandlers;

namespace ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EngineContext.Instance.Initialize(new AutofacFactory(
                builder =>
                {
                    // Unit of Work
                    builder.RegisterType<ContentContext>().As<IContentContext>().InstancePerLifetimeScope();
                    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
                    builder.RegisterType<SimpleErrorHandlerFactory>().As<IErrorHandlerFactory>().SingleInstance();
                },
                new AutofacRegisterAdmin(),
                container => { }));

            //var itemTypeModel = new GetItemTypeModel();
            //var install = new Installation();
            var registerNewUser = new RegisterNewUser();
            //var logCode = new GetLogCodeAttributes();
            //var sourceTree = new GetSourceTreeModel();
            //var user = new GetUserModel();
            //var membership = new DebugMembershipService();


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
