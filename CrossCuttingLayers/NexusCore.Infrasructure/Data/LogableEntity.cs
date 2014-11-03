using System;

namespace NexusCore.Infrasructure.Data
{
    public class LogableEntity : Entity, ILogable
    {
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
