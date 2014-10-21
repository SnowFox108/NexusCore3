using Autofac;
using NexusCore.Common.Adapter.IoC;

namespace NexusCore.Core.Web.Adapter.IoC
{
    public class AutofacRegisterWeb : IDiRegister
    {
        protected ContainerBuilder Builder;

        public void SetBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public void Register()
        {
        }

    }
}
