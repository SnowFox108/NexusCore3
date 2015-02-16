using NexusCore.Common.Data.Models.Websites;

namespace NexusCore.Common.Data.Models.Installation
{
    public class InstallationWebsiteModel
    {
        public WebsiteModel Website { get; set; }
        public DomainModel Domain { get; set; }
        public bool IsSkip { get; set; }
    }
}
