﻿using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Infrastructure;
using NexusCore.Data.Infrastructure;
using NexusCore.UILogic.Routing;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(NexusCore.Web.ModuleConfig), "Start")]
[assembly: ApplicationShutdownMethodAttribute(typeof(NexusCore.Web.ModuleConfig), "Stop")]

namespace NexusCore.Web
{
    public class ModuleConfig
    {
        public static void Start()
        {
            EngineConfig();
            DynamicModuleUtility.RegisterModule(typeof(DomainHandler));
        }

        public static void Stop()
        {

        }

        private static void EngineConfig()
        {
            // Dependancy Injection initialize
            EngineContext.Instance.DiContainerInitialize(new AutofacFactory(
                builder =>
                {
                    builder.RegisterControllers(typeof(MvcApplication).Assembly);
                    builder.RegisterType<ContentContext>().As<IContentContext>().InstancePerLifetimeScope();
                    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
                },
                new AutofacRegisterWebApi(),
                container => DependencyResolver.SetResolver(new AutofacDependencyResolver(container))));
            
        }

    }
}