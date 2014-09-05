using System.Data.Entity.ModelConfiguration;
using NexusCore.Common.Data.Entities.Membership;

namespace NexusCore.Data.Mapping.Membership
{
    internal class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            this.HasMany(u => u.Roles)
                .WithMany(p => p.Users)
                .Map(
                    m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RoleId");
                        m.ToTable("UsersInRoles");
                    });
        }
    }
}
