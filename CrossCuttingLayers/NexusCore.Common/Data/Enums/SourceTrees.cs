
namespace NexusCore.Common.Data.Enums
{
    public enum SourceTreeItemType
    {
        MasterRoot = 1,
        Client = 5,
        WebsiteRoot = 10,
        Website = 11,
        MenuRoot = 15,
        Menu = 16,
        MenuItem = 17,
        PageRoot = 20,
        Layout = 25,
        Page = 30,
        ModuleRoot = 50,
        Module = 55,
        ContentRoot = 60,
        Category = 65,
        None = 100
    }

    public enum SourceTreeItemModuleType
    {
        // one on one
        System = 1,
        // one on one
        ModuleItem = 2,
        // one on many
        ModuleItems = 3
    }

    public enum SourceTreePermissionType
    {
        ByRole = 1,
        ByUser = 2
    }
}
