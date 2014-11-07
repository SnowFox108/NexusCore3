using AutoMapper;
using NexusCore.Common.Data.Entities.Clients;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Helper.Extensions;

namespace NexusCore.Common.Data.MappingProfiles
{
    public class ClientProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Client, ClientModel>()
                .IgnoreAllMissingInTarget();
            Mapper.CreateMap<ClientModel, Client>()
                .IgnoreAllMissingInTarget();


            Mapper.CreateMap<ClientDepartment, ClientDepartmentModel>()
                .IgnoreAllMissingInTarget();
            Mapper.CreateMap<ClientDepartmentModel, ClientDepartment>()
                .IgnoreAllMissingInTarget();
        }
    }
}
