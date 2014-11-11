using AutoMapper;
using NexusCore.Common.Data.Entities.Website;
using NexusCore.Common.Data.Models.Websites;
using NexusCore.Common.Helper.Extensions;

namespace NexusCore.Common.Data.MappingProfiles
{
    public class WebsiteProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Domain, DomainModel>()
                .IgnoreAllMissingInTarget();
            Mapper.CreateMap<DomainModel, Domain>()
                .IgnoreAllMissingInTarget();

            Mapper.CreateMap<Website, WebsiteModel>()
                .IgnoreAllMissingInTarget();
            Mapper.CreateMap<WebsiteModel, Website>()
                .IgnoreAllMissingInTarget();
        }
    }
}
