using NexusCore.Common.Data.Models.CommonModels;

namespace NexusCore.Common.Data.Models.Memberships
{
    public class RoleSearchFilter
    {
        // search
        public string RoleName { get; set; }

        // Filter
        public PagingAndSortingModel Filter { get; set; }

        public RoleSearchFilter()
        {
            Filter = new PagingAndSortingModel("RoleName");
        }
    }
}
