
using NexusCore.Infrasructure.Model.Enums;

namespace NexusCore.Common.Data.Models.CommonModels
{
    public class PagingAndSortingModel
    {
        public SortingModel Sorting { get; set; }
        public PaginationModel Paging { get; set; }

        public PagingAndSortingModel(string sortColumn)
        {
            Sorting = new SortingModel
            {
                SortOrder = sortColumn,
                SortDirection = SortDirection.Asc
            };
            Paging = new PaginationModel
            {
                ItemsPerPage = 10,
                CurrentPage = 1
            };            
        }
    }
}
