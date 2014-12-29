using AutoMapper;
using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Helper.Extensions;

namespace NexusCore.Common.Data.MappingProfiles
{
    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            // single binding
            Mapper.CreateMap<User, CurrentUserModel>()
                .IgnoreAllMissingInTarget();

            // two way binding
            Mapper.CreateMap<User, UserModel>()
                .IgnoreAllMissingInTarget();
            Mapper.CreateMap<UserModel, User>()
                .IgnoreAllMissingInTarget();

        }
    }
}
