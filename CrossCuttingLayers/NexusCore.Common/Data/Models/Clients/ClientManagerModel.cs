using System.Collections.Generic;
using NexusCore.Common.Data.Models.CommonModels;

namespace NexusCore.Common.Data.Models.Clients
{
    public class ClientManagerModel
    {
        public IEnumerable<ClientModel> Clients { get; set; }
        public PaginationModel Paging { get; set; }
    }
}
