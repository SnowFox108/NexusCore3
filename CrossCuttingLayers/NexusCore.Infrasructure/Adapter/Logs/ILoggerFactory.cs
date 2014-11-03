
using NexusCore.Infrasructure.Adapter.Logs;

namespace NexusCore.Infrasructure.Adapter.Logging
{
    public interface ILoggerFactory
    {
        ILogger Create();
    }
}
