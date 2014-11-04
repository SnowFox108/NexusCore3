using System;
using NexusCore.Common.Data.Entities.Logs;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Infrastructure;
using NexusCore.Data.Infrastructure;
using NexusCore.Infrasructure.Adapter.Logs;
using NexusCore.Infrasructure.Models.Enums;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Core.Adapter.Logs
{
    public class SimpleLogger : ILogger
    {
        public void Debug(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args)
        {
            CreateLogging(new Logging
            {
                ClientId = clientId,
                ModuleId = moduleId,
                Category = category,
                Level = LogLevel.Debug,
                Message = message,
                LogCode = logCode,
                LogValues = string.Join("|", args)
            });
        }

        public void Fatal(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args)
        {
            throw new NotImplementedException();
        }

        private void CreateLogging(Logging logging)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(EngineContext.Instance.DiContainer.GetInstance<ICurrentUserProvider>()))
            {
                unitOfWork.Repository<Logging>().Insert(logging);
                unitOfWork.SaveChanges();
            }
        }

    }
}
