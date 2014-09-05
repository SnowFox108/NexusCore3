using System;
using Autofac;
using NexusCore.Common.Adapter.Mapping;
using NexusCore.Infrasructure.Adapter.IoC;
using NexusCore.Infrasructure.Adapter.Mapping;

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

        }
    }
}
