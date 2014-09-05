using AutoMapper;
using NexusCore.Infrasructure.Adapter.Mapping;

namespace NexusCore.Common.Adapter.Mapping
{
    public class AutoMapperAdapter : IMapperAdapter
    {
        /// <summary>
        /// AutoMapper adapter
        /// </summary>
        /// <typeparam name="TSource">Source class type</typeparam>
        /// <typeparam name="TTarget">Target class type</typeparam>
        /// <param name="source">Source class</param>
        /// <returns>Target class</returns>
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        /// <summary>
        /// AutoMapper adapter
        /// </summary>
        /// <typeparam name="TTarget">Target class type</typeparam>
        /// <param name="source">Source class</param>
        /// <returns>Target class</returns>
        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }
    }
}
