using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NexusCore.Infrasructure.Adapter.Mapping;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static IMapperAdapterFactory Factory { get; set; }

        public static TTarget MapTo<TTarget>(this Entity item) where TTarget : class, new()
        {
            var adapter = Factory.Create();
            return adapter.Adapt<TTarget>(item);
        }

        public static List<TTarget> MapTo<TTarget>(this IEnumerable<Entity> items)
            where TTarget : class, new()
        {
            var adapter = Factory.Create();
            return adapter.Adapt<List<TTarget>>(items);
        }

        public static IMappingExpression<TSource, TTarget> IgnoreAllNonExistingInTarget<TSource, TTarget>(this IMappingExpression<TSource, TTarget> expression)
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);
            foreach (var prop in Mapper.GetAllTypeMaps().First(m => m.SourceType == sourceType && m.DestinationType == targetType).GetUnmappedPropertyNames())
            {
                expression.ForMember(prop, opt => opt.Ignore());
            }
            return expression;
        }
    }
}
