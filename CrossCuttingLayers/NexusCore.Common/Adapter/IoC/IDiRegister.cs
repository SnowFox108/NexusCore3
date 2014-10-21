
using Autofac;

namespace NexusCore.Common.Adapter.IoC
{
    public interface IDiRegister
    {
        void SetBuilder(ContainerBuilder builder);
        void Register();
    }
}
