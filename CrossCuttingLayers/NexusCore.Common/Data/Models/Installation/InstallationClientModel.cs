using NexusCore.Common.Data.Models.Clients;

namespace NexusCore.Common.Data.Models.Installation
{
    public class InstallationClientModel : ClientCreateModel
    {
        public bool IsSkip { get; set; }
    }
}
