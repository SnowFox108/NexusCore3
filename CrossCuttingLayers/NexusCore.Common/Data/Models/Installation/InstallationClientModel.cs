using NexusCore.Common.Data.Models.ClientModels;

namespace NexusCore.Common.Data.Models.Installation
{
    public class InstallationClientModel : ClientCreateModel
    {
        public bool IsSkip { get; set; }
    }
}
