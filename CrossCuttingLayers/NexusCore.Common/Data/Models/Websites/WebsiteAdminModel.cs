using NexusCore.Common.Data.Models.Clients;

namespace NexusCore.Common.Data.Models.Websites
{
    public class WebsiteAdminModel
    {
        public WebsiteModel Website { get; set; }
        public ClientModel Client { get; set; }
    }
}
