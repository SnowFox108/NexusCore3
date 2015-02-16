using System.Collections.Generic;
using NexusCore.Common.Data.Models.CommonModels;

namespace NexusCore.Common.Data.Models.Websites
{
    public class WebsiteManagerModel
    {
        public IEnumerable<WebsiteAdminModel> Websites { get; set; }
        public PaginationModel Paging { get; set; }

    }
}
