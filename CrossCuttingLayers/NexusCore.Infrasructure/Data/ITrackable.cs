using System;

namespace NexusCore.Infrasructure.Data
{
    public interface ITrackable
    {
        DateTime CreatedDate { get; set; }
        Guid CreatedBy { get; set; }
        DateTime UpdatedDate { get; set; }
        Guid UpdatedBy { get; set; }
    }
}