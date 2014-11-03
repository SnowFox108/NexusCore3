using System;

namespace NexusCore.Infrasructure.Data
{
    public class TrackableEntity : LogableEntity , ITrackable
    {
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
