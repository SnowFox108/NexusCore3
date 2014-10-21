using System;
using Autofac;
using NexusCore.Infrasructure.Adapter.IoC;

namespace NexusCore.Common.Adapter.IoC
{
    public class AutofacFactory : IDiContainerFactory
    {
        private readonly IContainer _container;

        public AutofacFactory(Action<ContainerBuilder> preRegister, IDiRegister register, Action<IContainer> resolver)
        {
            var builder = new ContainerBuilder();
            preRegister(builder);
            // init register
            Register(builder, register);
            _container = builder.Build();
            resolver(_container);
        }

        private void Register(ContainerBuilder builder, IDiRegister register)
        {
            //var autofacRegister = register as IAutofacRegister;
            //if (autofacRegister == null) return;
            //var initRegister = autofacRegister;
            //initRegister.SetBuilder(builder);
            //initRegister.Register();
            register.SetBuilder(builder);
            register.Register();
        }

        public IDiContainer Create()
        {
            return new AutofacContainer(_container);
        }
    }
}
