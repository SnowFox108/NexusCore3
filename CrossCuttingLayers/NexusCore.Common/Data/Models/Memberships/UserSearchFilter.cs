using NexusCore.Common.Data.Models.CommonModels;

namespace NexusCore.Common.Data.Models.Memberships
{
    public class UserSearchFilter
    {
        // Search
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Filter
        public PagingAndSortingModel Filter { get; set; }

        public UserSearchFilter()
        {
            Filter = new PagingAndSortingModel("FirstName");
        }
    }
}
