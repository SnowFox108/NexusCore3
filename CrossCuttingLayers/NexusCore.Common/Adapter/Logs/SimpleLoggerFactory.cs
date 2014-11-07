using NexusCore.Common.Data.Infrastructure;
using NexusCore.Infrasructure.Adapter.Logging;
using NexusCore.Infrasructure.Adapter.Logs;

namespace NexusCore.Common.Adapter.Logs
{
    public class SimpleLoggerFactory: ILoggerFactory
    {

        private readonly IUnitOfWorkAsyncFactory _unitOfWorkAdapter;

        public SimpleLoggerFactory(IUnitOfWorkAsyncFactory unitOfWorkAdapter)
        {
            _unitOfWorkAdapter = unitOfWorkAdapter;
        }

        public ILogger Create()
        {
            return new SimpleLogger(_unitOfWorkAdapter);
        }
    }
}
