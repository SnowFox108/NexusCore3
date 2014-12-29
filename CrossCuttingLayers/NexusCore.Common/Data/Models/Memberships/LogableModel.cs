using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Models.Memberships
{
    public class LogableModel : LogableEntity
    {
        public CurrentUserModel CreatedByUser { get; set; }
    }
}
