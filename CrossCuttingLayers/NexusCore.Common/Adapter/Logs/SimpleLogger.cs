using System;
using NexusCore.Common.Data.Entities.Logs;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Infrasructure.Adapter.Logs;
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Common.Adapter.Logs
{
    public class SimpleLogger : ILogger
    {
        private readonly IUnitOfWorkAsyncFactory _unitOfWorkFactory;

        public SimpleLogger(IUnitOfWorkAsyncFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Debug(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args)
        {
            Log(message, clientId, moduleId, category, LogLevel.Debug, logCode, args);
        }

        public void Fatal(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args)
        {
            Log(message, clientId, moduleId, category, LogLevel.Critical, logCode, args);
        }

        public void LogInfo(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args)
        {
            Log(message, clientId, moduleId, category, LogLevel.Information, logCode, args);
        }

        public void LogWarning(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args)
        {
            Log(message, clientId, moduleId, category, LogLevel.Warning, logCode, args);
        }

        public void LogError(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args)
        {
            Log(message, clientId, moduleId, category, LogLevel.Error, logCode, args);
        }

        public void Log(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(), TaskCategory category = TaskCategory.None, LogLevel logLevel = LogLevel.Information, LogCode logCode = LogCode.None, params object[] args)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.Repository<Logging>().Insert(new Logging
                {
                    ClientId = clientId,
                    ModuleId = moduleId,
                    Category = category,
                    Level = logLevel,
                    Message = message,
                    LogCode = logCode,
                    LogValues = string.Join("|", args)
                });
                unitOfWork.SaveChanges();
            }
        }
    }
}
