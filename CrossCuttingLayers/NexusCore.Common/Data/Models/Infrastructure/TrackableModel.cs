using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Models.Infrastructure
{
    public class TrackableModel : TrackableEntity
    {
        public CurrentUserModel CreatedByUser { get; set; }
        public CurrentUserModel UpdatedByUser { get; set; }
    }
}
