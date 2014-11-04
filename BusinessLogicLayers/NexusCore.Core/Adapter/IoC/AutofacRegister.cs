using System;
using Autofac;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Adapter.Mapping;
using NexusCore.Common.Security;
using NexusCore.Common.Services;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.FriendlyIdServices;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Core.Adapter.Logs;
using NexusCore.Core.Services.ClientComponent;
using NexusCore.Core.Services.ClientComponent.Aggregate;
using NexusCore.Core.Services.ClientComponent.Primitive;
using NexusCore.Core.Services.FriendlyIdGenerator.Primitive;
using NexusCore.Core.Services.Infrastructure;
using NexusCore.Core.Services.SourceTreeComponent.Aggregate;
using NexusCore.Core.Services.SourceTreeComponent.Primitive;
using NexusCore.Infrasructure.Adapter.Logging;
using NexusCore.Infrasructure.Adapter.Mapping;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Core.Adapter.IoC
{
    public class AutofacRegister : IDiRegister
    {
        protected ContainerBuilder Builder;

        public void SetBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public virtual void Register()
        {
            if (Builder == null)
                throw new Exception("Builder has not been initialized");

            // common register
            Builder.RegisterType<SimpleAuthenticationManager>().As<IAuthenticationManager>();
            Builder.RegisterType<CurrentUserProvider>().As<ICurrentUserProvider>();
            Builder.RegisterType<AutoMapperAdapterFactory>().As<IMapperAdapterFactory>().SingleInstance();
            Builder.RegisterType<PasswordValidtor>().As<IPasswordValidator>();

            // services
            Builder.RegisterType<PrimitiveServices>().As<IPrimitiveServices>().InstancePerLifetimeScope();
            Builder.RegisterType<AggregateServices>().As<IAggregateServices>().InstancePerLifetimeScope();
            Builder.RegisterType<ComponentServices>().As<IComponentServices>().InstancePerLifetimeScope();

            // Client
            Builder.RegisterType<ClientAggregate>().As<IClientAggregate>().InstancePerLifetimeScope();
            Builder.RegisterType<ClientDepartmentPrimitive>()
                .As<IClientDepartmentPrimitive>()
                .InstancePerLifetimeScope();
            Builder.RegisterType<ClientPrimitive>().As<IClientPrimitive>().InstancePerLifetimeScope();
            Builder.RegisterType<ClientService>().As<IClientService>().InstancePerLifetimeScope();

            // Misc
            Builder.RegisterType<FriendlyIdPrimitive>().As<IFriendlyIdPrimitive>().InstancePerLifetimeScope();

            // sourceTree service
            Builder.RegisterType<SourceTreeAggregate>().As<ISourceTreeAggregate>().InstancePerLifetimeScope();
            Builder.RegisterType<SourceTreePrimitive>().As<ISourceTreePrimitive>().InstancePerLifetimeScope();

        }
    }
}
