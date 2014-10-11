using System;
using Autofac;
using NexusCore.Common.Adapter.Mapping;
using NexusCore.Common.Security;
using NexusCore.Infrasructure.Adapter.IoC;
using NexusCore.Infrasructure.Adapter.Mapping;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Common.Adapter.IoC
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
            Builder.RegisterType<AutoMapperAdapterFacotry>().As<IMapperAdapterFactory>().SingleInstance();
            Builder.RegisterType<SimpleAuthenticationManager>().As<IAuthenticationManager>();
            Builder.RegisterType<PasswordValidtor>().As<IPasswordValidator>();
        }
    }
}
