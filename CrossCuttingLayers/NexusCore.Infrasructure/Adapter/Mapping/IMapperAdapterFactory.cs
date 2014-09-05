namespace NexusCore.Infrasructure.Adapter.Mapping
{
    /// <summary>
    /// Base contract for adapter factory
    /// </summary>
    public interface IMapperAdapterFactory
    {
        /// <summary>
        /// Create a type adater
        /// </summary>
        /// <returns>The created IMapperAdapter</returns>
        IMapperAdapter Create();
    }
}
