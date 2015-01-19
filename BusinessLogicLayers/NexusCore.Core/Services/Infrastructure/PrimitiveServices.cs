using NexusCore.Common.Services;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.FriendlyIdServices;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Common.Services.MessageServices;
using NexusCore.Common.Services.PermissionServices;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Common.Services.WebsiteServices;

namespace NexusCore.Core.Services.Infrastructure
{
    public class PrimitiveServices : IPrimitiveServices
    {
        public IClientPrimitive ClientPrimitive { get; set; }

        public IDomainPrimitive DomainPrimitive { get; set; }

        public IFriendlyIdPrimitive FriendlyIdPrimitive { get; set; }

        public IMailTemplatePrimitive MailTemplatePrimitive { get; set; }

        public IItemInSourceTreePrimitive ItemInSourceTreePrimitive { get; set; }

        public IPermissionPrimitive PermissionPrimitive { get; set; }

        public ISourceTreePrimitive SourceTreePrimitive { get; set; }

        public IUserPrimitive UserPrimitive { get; set; }

        public IWebsitePrimitive WebsitePrimitive { get; set; }

        public IWebsiteSettingPrimitive WebsiteSettingPrimitive { get; set; }
    }
}
