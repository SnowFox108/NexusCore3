using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Infrastructure;
using NexusCore.Infrasructure.Adapter.Logging;
using NexusCore.Infrasructure.Adapter.Logs;

namespace NexusCore.Common.Adapter.Logs
{
    public static class LoggerAdapter
    {
        private static readonly ILoggerFactory LoggerFactory;

        static LoggerAdapter()
        {
            LoggerFactory = new SimpleLoggerFactory(EngineContext.Instance.DiContainer.GetInstance<IUnitOfWorkAsyncFactory>());
        }

        public static ILogger Logger
        {
            get { return LoggerFactory.Create(); }
        }
    }
}
