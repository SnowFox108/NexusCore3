using System.Collections.Generic;
using System.Linq;
using NexusCore.Common.Data.Enums;
using NexusCore.Common.Data.Models.SourceTrees;

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
            _sourceTreeItemTypes = new List<SourceTreeItemTypeModel>
            {
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.MasterRoot,
                    Name = "Master Root",
                    Icon = "",
                    IsRoot = true,
                    IsSignleItemLinked = true,
                    Constraints = Enumerable.Empty<SourceTreeItemType>()
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.Client,
                    Name = "Client",
                    Icon = "",
                    IsRoot = true,
                    IsSignleItemLinked = true,
                    Constraints = Enumerable.Empty<SourceTreeItemType>()
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.WebsiteRoot,
                    Name = "Websites",
                    Icon = "",
                    IsRoot = true,
                    IsSignleItemLinked = true,
                    Constraints = Enumerable.Empty<SourceTreeItemType>()
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.Website,
                    Name = "Website",
                    Icon = "",
                    IsRoot = true,
                    IsSignleItemLinked = true,
                    Constraints = Enumerable.Empty<SourceTreeItemType>()
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.MenuRoot,
                    Name = "Menus",
                    Icon = "",
                    IsRoot = true,
                    IsSignleItemLinked = true,
                    Constraints = Enumerable.Empty<SourceTreeItemType>()
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.Menu,
                    Name = "Menu",
                    Icon = "",
                    IsRoot = true,
                    IsSignleItemLinked = true,
                    Constraints = new []
                    {
                        SourceTreeItemType.MenuItem
                    }
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.MenuItem,
                    Name = "Menu Item",
                    Icon = "",
                    IsRoot = false,
                    IsSignleItemLinked = true,
                    Constraints = new []
                    {
                        SourceTreeItemType.MenuItem
                    }
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.PageRoot,
                    Name = "Pages",
                    Icon = "",
                    IsRoot = true,
                    IsSignleItemLinked = true,
                    Constraints = new []
                    {
                        SourceTreeItemType.Layout
                    }
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.Layout,
                    Name = "Layout",
                    Icon = "",
                    IsRoot = true,
                    IsSignleItemLinked = true,
                    Constraints = new []
                    {
                        SourceTreeItemType.Page
                    }
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.Page,
                    Name = "Page",
                    Icon = "",
                    IsRoot = false,
                    IsSignleItemLinked = true,
                    Constraints = new []
                    {
                        SourceTreeItemType.Page
                    }
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.ModuleRoot,
                    Name = "Modules",
                    Icon = "",
                    IsRoot = true,
                    IsSignleItemLinked = true,
                    Constraints = new []
                    {
                        SourceTreeItemType.Module
                    }
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.Module,
                    Name = "Module",
                    Icon = "",
                    IsRoot = true,
                    IsSignleItemLinked = false,
                    Constraints = Enumerable.Empty<SourceTreeItemType>()
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.ContentRoot,
                    Name = "Contents",
                    Icon = "",
                    IsRoot = true,
                    IsSignleItemLinked = true,
                    Constraints = new []
                    {
                        SourceTreeItemType.Category
                    }
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.Category,
                    Name = "Category",
                    Icon = "",
                    IsRoot = false,
                    IsSignleItemLinked = false,
                    Constraints = new []
                    {
                        SourceTreeItemType.Category
                    }
                },
                new SourceTreeItemTypeModel
                {
                    ItemType = SourceTreeItemType.None,
                    Name = "None",
                    Icon = "",
                    IsRoot = true,
                    Constraints = Enumerable.Empty<SourceTreeItemType>()
                },
            };            
        }

    }
}
