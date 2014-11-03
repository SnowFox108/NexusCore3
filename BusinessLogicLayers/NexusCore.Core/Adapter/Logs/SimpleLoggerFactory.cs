using NexusCore.Infrasructure.Adapter.Logging;
using NexusCore.Infrasructure.Adapter.Logs;

namespace NexusCore.Core.Adapter.Logs
{
    public class SimpleLoggerFactory: ILoggerFactory
    {
        public ILogger Create()
        {
            return new SimpleLogger();
        }
    }
}
