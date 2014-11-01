using System;
using System.Linq;
using NexusCore.Common.Data.Entities.SourceTrees;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Values.SourceTree;
using NexusCore.Common.Infrastructure;

namespace ClientTest
{
    public class GetItemTypeModel
    {
        public GetItemTypeModel()
        {
            //var item = new SourceTreeModel()
            //{
            //    Id = Guid.NewGuid(),
            //    ParentId = new Guid(),
            //    Name = "Test Client",
            //    ItemType = SourceTreeItemType.Client
            //};

            //Console.WriteLine("Type Name is {0} and root is {1}", item.ItemType.Value().Name, item.ItemType.Value().IsRoot);
            var unitOfWork = EngineContext.Instance.DiContainer.GetInstance<IUnitOfWork>();

            var filter = SourceTreeItemTypeValues.Instance.Values.Where(v => v.IsRoot).Select(v => v.ItemType);
            var results = unitOfWork.Repository<SourceTree>().Get(s => filter.Contains(s.ItemType));

            foreach (var sourceTree in results)
            {
                Console.WriteLine("Id: {0} Name: {1}", sourceTree.Id, sourceTree.Name);
            }
        }
    }
}
