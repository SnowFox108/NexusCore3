using System;

namespace NexusCore.Infrasructure.Data
{
    public interface ITrackable : ILogable
    {
        DateTime UpdatedDate { get; set; }
        Guid UpdatedBy { get; set; }
    }
}