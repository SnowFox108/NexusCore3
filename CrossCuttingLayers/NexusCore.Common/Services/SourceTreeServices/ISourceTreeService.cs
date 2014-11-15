using NexusCore.Common.Data.Models.SourceTrees;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface ISourceTreeService
    {
        SourceTreeModel GetSourceTreeBuild();
    }
}
