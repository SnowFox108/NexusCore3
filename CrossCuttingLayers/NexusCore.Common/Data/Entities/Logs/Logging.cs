using System;
using NexusCore.Infrasructure.Data;
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Common.Data.Entities.Logs
{
    public class Logging : LogableEntity
    {
        public Guid ClientId { get; set; }
        public Guid ModuleId { get; set; }
        public TaskCategory Category { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public LogCode LogCode { get; set; }
        public string LogValues { get; set; }
    }
}
