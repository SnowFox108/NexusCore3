using System;

namespace NexusCore.Infrasructure.Data
{
    public class TrackableEntity : Entity , ITrackable
    {
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
