using System;
using NexusCore.Common.Data.Models.CommonModels;

namespace NexusCore.Common.Data.Models.Websites
{
    public class WebsiteSearchFilter
    {
        // Search
        public Guid ClientId { get; set; }

        public string FriendlyId { get; set; }
        public string Name { get; set; }

        public string DomainName { get; set; }
        
        // Filter
        public PagingAndSortingModel Filter { get; set; }

        public WebsiteSearchFilter()
        {
            Filter = new PagingAndSortingModel("Name");
        }
    }
}
