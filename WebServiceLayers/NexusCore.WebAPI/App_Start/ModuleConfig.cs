using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(NexusCore.WebAPI.ModuleConfig), "Start")]
[assembly: ApplicationShutdownMethodAttribute(typeof(NexusCore.WebAPI.ModuleConfig), "Stop")]

namespace NexusCore.WebAPI
{
    public class ModuleConfig
    {
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(EngineConfig));
        }

        public static void Stop()
        {

        }
    }
}