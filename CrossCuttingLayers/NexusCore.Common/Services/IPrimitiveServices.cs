using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.FriendlyIdServices;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Common.Services.MessageServices;
using NexusCore.Common.Services.PermissionServices;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Common.Services.WebsiteServices;

namespace NexusCore.Common.Services
{
    public interface IPrimitiveServices
    {
        IClientPrimitive ClientPrimitive { get; }
        IDomainPrimitive DomainPrimitive { get; }
        IFriendlyIdPrimitive FriendlyIdPrimitive { get; }
        IMailTemplatePrimitive MailTemplatePrimitive { get; }
        IItemInSourceTreePrimitive ItemInSourceTreePrimitive { get; }
        IPermissionPrimitive PermissionPrimitive { get; }
        ISourceTreePrimitive SourceTreePrimitive { get; }
        IUserPrimitive UserPrimitive { get; }
        IWebsitePrimitive WebsitePrimitive { get; }
        IWebsiteSettingPrimitive WebsiteSettingPrimitive { get; }
    }
}
