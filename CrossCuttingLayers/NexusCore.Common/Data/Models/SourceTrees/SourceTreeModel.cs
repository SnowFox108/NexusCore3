using System;
using System.Collections.Generic;

namespace NexusCore.Common.Data.Models.SourceTrees
{
    public class SourceTreeModel
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }

        public SourceTreeItemTypeModel ItemType { get; set; }

        private readonly List<SourceTreeModel> _childNodes;

        public List<SourceTreeModel> ChildNodes {
            get { return _childNodes; }
        }

        public SourceTreeModel()
        {
            _childNodes = new List<SourceTreeModel>();
        }
    }
}
