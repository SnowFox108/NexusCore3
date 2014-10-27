
using Autofac;
using NexusCore.Common.Services.InstallationServices;
using NexusCore.Core.Services.InstallationComponent;

namespace NexusCore.Core.Adapter.IoC
{
    public class AutofacRegisterAdmin : AutofacRegister
    {
        public override void Register()
        {
            base.Register();
            Builder.RegisterType<InstallationService>().As<IInstallationService>();
        }
    }
}
