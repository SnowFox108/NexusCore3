using System;
using Autofac;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Adapter.Mapping;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Security;
using NexusCore.Common.Services;
using NexusCore.Core.Services;
using NexusCore.Data.Infrastructure;
using NexusCore.Infrasructure.Adapter.IoC;
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

            // Unit of Work
            Builder.RegisterType<ContentContext>().As<IContentContext>().InstancePerLifetimeScope();
            Builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();

            // common register
            Builder.RegisterType<SimpleAuthenticationManager>().As<IAuthenticationManager>();
            Builder.RegisterType<CurrentUserProvider>().As<ICurrentUserProvider>();
            Builder.RegisterType<AutoMapperAdapterFacotry>().As<IMapperAdapterFactory>().SingleInstance();
            Builder.RegisterType<PasswordValidtor>().As<IPasswordValidator>();

            // services
            Builder.RegisterType<PrimitiveServices>().As<IPrimitiveServices>().InstancePerLifetimeScope();
            Builder.RegisterType<AggregateServices>().As<IAggregateServices>().InstancePerLifetimeScope();
            Builder.RegisterType<ComponentServices>().As<IComponentServices>().InstancePerLifetimeScope();

        }
    }
}
