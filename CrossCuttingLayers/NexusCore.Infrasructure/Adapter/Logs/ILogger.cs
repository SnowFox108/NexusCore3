using System;
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Infrasructure.Adapter.Logs
{
    public interface ILogger
    {

        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="message">The debug message to write</param>
        /// <param name="clientId">related client</param>
        /// <param name="moduleId">related module</param>
        /// <param name="category">Log category</param>
        /// <param name="logCode">MessageId</param>
        /// <param name="args">The argument values</param>
        void Debug(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(),
            TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args);


        /// <summary>
        /// Log Fatal error
        /// </summary>
        /// <param name="message">The fatal message to write</param>
        /// <param name="clientId">related client</param>
        /// <param name="moduleId">related module</param>
        /// <param name="category">Log category</param>
        /// <param name="logCode">MessageId</param>
        /// <param name="args">The argument values</param>
        void Fatal(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(),
            TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args);

        /// <summary>
        /// Log message information 
        /// </summary>
        /// <param name="message">The info message to write</param>
        /// <param name="clientId">related client</param>
        /// <param name="moduleId">related module</param>
        /// <param name="category">Log category</param>
        /// <param name="logCode">MessageId</param>
        /// <param name="args">The argument values</param>
        void LogInfo(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(),
            TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args);



        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message">The warning message to write</param>
        /// <param name="clientId">related client</param>
        /// <param name="moduleId">related module</param>
        /// <param name="category">Log category</param>
        /// <param name="logCode">MessageId</param>
        /// <param name="args">The argument values</param>
        void LogWarning(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(),
            TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args);


        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="clientId">related client</param>
        /// <param name="moduleId">related module</param>
        /// <param name="category">Log category</param>
        /// <param name="logCode">MessageId</param>
        /// <param name="args">The argument values</param>
        void LogError(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(),
            TaskCategory category = TaskCategory.None, LogCode logCode = LogCode.None, params object[] args);


        /// <summary>
        /// General Log message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="clientId">related client</param>
        /// <param name="moduleId">related module</param>
        /// <param name="category">Log category</param>
        /// <param name="logLevel">Log level</param>
        /// <param name="logCode">MessageId</param>
        /// <param name="args">The arguments values</param>
        void Log(string message, Guid clientId = new Guid(), Guid moduleId = new Guid(),
            TaskCategory category = TaskCategory.None, LogLevel logLevel = LogLevel.Information, LogCode logCode = LogCode.None, params object[] args);


    }
}
