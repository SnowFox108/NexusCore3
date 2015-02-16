using NexusCore.Common.Data.Models.CommonModels;

namespace NexusCore.Common.Data.Models.Clients
{
    public class ClientSearchFilter
    {
        // Filter
        public PagingAndSortingModel Filter { get; set; }

        public ClientSearchFilter()
        {
            Filter = new PagingAndSortingModel("Name");
        }

    }
}
