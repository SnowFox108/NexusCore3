using System.Collections.Generic;
using NexusCore.Common.Data.Models.SourceTree;

namespace NexusCore.Common.Data.Values.SourceTree
{
    public class SourceTreeItemTypeValues
    {
        private readonly IEnumerable<SourceTreeItemTypeModel> _sourceTreeItemTypes;

        public IEnumerable<SourceTreeItemTypeModel> Values { get { return _sourceTreeItemTypes; } } 

        private static SourceTreeItemTypeValues _instance;

        public static SourceTreeItemTypeValues Instance
        {
            get { return _instance ?? (_instance = new SourceTreeItemTypeValues()); }
        }

        public SourceTreeItemTypeValues()
        {
            _sourceTreeItemTypes = new List<SourceTreeItemTypeModel>()
            {
                new SourceTreeItemTypeModel()
                {
                    ItemType = SourceTreeItemType.Client,
                    Name = "Client",
                    Icon = "",
                    IsRoot = true
                }
            };            
        }

    }
}
