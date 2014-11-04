using NexusCore.Infrasructure.Adapter.Logging;
using NexusCore.Infrasructure.Adapter.Logs;

namespace NexusCore.Core.Adapter.Logs
{
    public static class LoggerAdapter
    {
        private static readonly ILoggerFactory LoggerFactory;

        static LoggerAdapter()
        {
            LoggerFactory = new SimpleLoggerFactory();
        }

        public static ILogger Logger
        {
            get { return LoggerFactory.Create(); }
        }
    }
}
