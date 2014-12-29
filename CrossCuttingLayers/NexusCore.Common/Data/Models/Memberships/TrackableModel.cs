using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Models.Memberships
{
    public class TrackableModel : TrackableEntity
    {
        public CurrentUserModel CreatedByUser { get; set; }
        public CurrentUserModel UpdatedByUser { get; set; }
    }
}
