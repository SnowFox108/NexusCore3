using System;

namespace NexusCore.Common.Services.SourceTreeServices
{
    public interface IItemInSourceTreePrimitive
    {
        Guid GetSourceTreeId(Guid itemId);
    }
}
