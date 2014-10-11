using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Common.Data.Infrastructure.Extensions;
using NexusCore.Common.Data.Models.SourceTree;

namespace ClientTest
{
    public class GetItemTypeModel
    {
        public GetItemTypeModel()
        {
            var item = new SourceTreeModel()
            {
                Id = Guid.NewGuid(),
                ParentId = new Guid(),
                Name = "Test Client",
                ItemType = SourceTreeItemType.Client
            };

            Console.WriteLine("Type Name is {0} and root is {1}", item.ItemType.Value().Name, item.ItemType.Value().IsRoot);
        }
    }
}
