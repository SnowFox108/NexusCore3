using System;

namespace NexusCore.Infrasructure.Data
{
    public interface ILogable
    {
        DateTime CreatedDate { get; set; }
        Guid CreatedBy { get; set; }
    }
}
