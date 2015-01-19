using System;
using Autofac;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Adapter.IoC;
using NexusCore.Common.Adapter.Mapping;
using NexusCore.Common.Adapter.Messager;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Security;
using NexusCore.Common.Services;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.FriendlyIdServices;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Common.Services.MessagerServices;
using NexusCore.Common.Services.PermissionServices;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Common.Services.WebsiteServices;
using NexusCore.Core.Services.ClientComponent;
using NexusCore.Core.Services.ClientComponent.Aggregate;
using NexusCore.Core.Services.ClientComponent.Primitive;
using NexusCore.Core.Services.FriendlyIdGenerator.Primitive;
using NexusCore.Core.Services.Infrastructure;
using NexusCore.Core.Services.MembershipComponent;
using NexusCore.Core.Services.MembershipComponent.Primitive;
using NexusCore.Core.Services.PermissionComponent.Aggregate;
using NexusCore.Core.Services.PermissionComponent.Primitive;
using NexusCore.Core.Services.SourceTreeComponent;
using NexusCore.Core.Services.SourceTreeComponent.Aggregate;
using NexusCore.Core.Services.SourceTreeComponent.Primitive;
using NexusCore.Core.Services.WebsiteComponent.Aggregate;
using NexusCore.Core.Services.WebsiteComponent.Primitive;
using NexusCore.Core.Utilities.Messager;
using NexusCore.Data.Infrastructure;
using NexusCore.Infrasructure.Adapter.ErrorHandlers;
using NexusCore.Infrasructure.Adapter.Mapping;
using NexusCore.Infrasructure.Adapter.Messager;
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
            Builder.RegisterType<AutoMapperAdapterFactory>().As<IMapperAdapterFactory>().SingleInstance();
            Builder.RegisterType<CurrentUserProvider>().As<ICurrentUserProvider>();
            Builder.RegisterType<PasswordValidtor>().As<IPasswordValidator>();
            Builder.RegisterType<SimpleAuthenticationManager>().As<IAuthenticationManager>();
            Builder.RegisterType<SimpleErrorHandler>().As<IErrorHandler>().InstancePerLifetimeScope();        
            Builder.RegisterType<UnitOfWorkAsyncFactory>().As<IUnitOfWorkAsyncFactory>();

            // services
            Builder.RegisterType<PrimitiveServices>().As<IPrimitiveServices>().InstancePerDependency().PropertiesAutowired();
            Builder.RegisterType<AggregateServices>().As<IAggregateServices>().InstancePerLifetimeScope().PropertiesAutowired();
            Builder.RegisterType<ComponentServices>().As<IComponentServices>().InstancePerLifetimeScope().PropertiesAutowired();

            // Client
            Builder.RegisterType<ClientAggregate>().As<IClientAggregate>().InstancePerLifetimeScope();
            Builder.RegisterType<ClientDepartmentPrimitive>()
                .As<IClientDepartmentPrimitive>()
                .InstancePerLifetimeScope();
            Builder.RegisterType<ClientPrimitive>().As<IClientPrimitive>().InstancePerLifetimeScope();
            Builder.RegisterType<ClientService>().As<IClientService>().InstancePerLifetimeScope();

            // Membership
            Builder.RegisterType<MembershipService>().As<IMembershipService>().InstancePerLifetimeScope();
            Builder.RegisterType<UserPrimitive>().As<IUserPrimitive>().InstancePerLifetimeScope();

            // Messager
            Builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerLifetimeScope();
            Builder.RegisterType<MessageService>().As<IMessageService>().InstancePerLifetimeScope();
            Builder.RegisterType<SmsSender>().As<ISmsSender>().InstancePerLifetimeScope();

            // Misc
            Builder.RegisterType<FriendlyIdPrimitive>().As<IFriendlyIdPrimitive>().InstancePerLifetimeScope();

            // Permission
            Builder.RegisterType<PermissionAggregate>().As<IPermissionAggregate>().InstancePerLifetimeScope();
            Builder.RegisterType<PermissionPrimitive>().As<IPermissionPrimitive>().InstancePerLifetimeScope();

            // SourceTree service
            Builder.RegisterType<ItemInSourceTreePrimitive>().As<IItemInSourceTreePrimitive>().InstancePerLifetimeScope();
            Builder.RegisterType<SourceTreeAggregate>().As<ISourceTreeAggregate>().InstancePerLifetimeScope();
            Builder.RegisterType<SourceTreePrimitive>().As<ISourceTreePrimitive>().InstancePerLifetimeScope();
            Builder.RegisterType<SourceTreeService>().As<ISourceTreeService>().InstancePerLifetimeScope();


            // Webiste
            Builder.RegisterType<DomainPrimitive>().As<IDomainPrimitive>().InstancePerLifetimeScope();
            Builder.RegisterType<WebsiteAggregate>().As<IWebsiteAggregate>().InstancePerLifetimeScope();
            Builder.RegisterType<WebsitePrimitive>().As<IWebsitePrimitive>().InstancePerLifetimeScope();
            Builder.RegisterType<WebsiteSettingPrimitive>().As<IWebsiteSettingPrimitive>().InstancePerLifetimeScope();


        }
    }
}
