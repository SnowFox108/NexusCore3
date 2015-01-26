
namespace NexusCore.Infrasructure.Security
{
    public static class DefaultUserRoles
    {
        public static readonly string[] SystemUserRoles =
        {
            "Administrators",
            "Super Moderators",
            "Moderators",
            "SEO Moderators",
            "Registered Users",
            "Guests",
            "Users Awaiting Moderation",
            "Banned Users"
        };

        public const string Administrators = "Administrators",
            SuperModerators = "Super Moderators",
            Moderators = "Moderators",
            SeoModerators = "SEO Moderators",
            RegisteredUsers = "Registered Users",
            Guest = "Guests",
            UsersAwaitingModeration = "Users Awaiting Moderation",
            BannedUsers = "Banned Users";
    }
}
