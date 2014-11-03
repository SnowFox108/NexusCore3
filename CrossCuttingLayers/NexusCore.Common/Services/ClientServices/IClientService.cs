using NexusCore.Common.Data.Models.ClientModels;

namespace NexusCore.Common.Services.ClientServices
{
    public interface IClientService
    {
        void CreateClient(ClientCreateModel client);
    }
}
