using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Models.Infrastructure
{
    public class LogableModel : LogableEntity
    {
        public CurrentUserModel CreatedByUser { get; set; }
    }
}
