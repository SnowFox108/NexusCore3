using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using AutoMapper;
using NexusCore.Common.Adapter.Mapping;
using NexusCore.Common.Infrastructure;
using NexusCore.Infrasructure.Attributes;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Helper.Extensions
{
    public static class EntityExtensions
    {

        #region Entity Extensions

        public static TTarget MapTo<TTarget>(this Entity item) where TTarget : class, new()
        {
            var adapter = EngineContext.Instance.DiContainer.GetInstance<AutoMapperAdapterFacotry>().Create();
            return adapter.Adapt<TTarget>(item);
        }

        public static List<TTarget> MapTo<TTarget>(this IEnumerable<Entity> items)
            where TTarget : class, new()
        {
            var adapter = EngineContext.Instance.DiContainer.GetInstance<AutoMapperAdapterFacotry>().Create();
            return adapter.Adapt<List<TTarget>>(items);
        }

        public static IMappingExpression<TSource, TTarget> IgnoreAllMissingInTarget<TSource, TTarget>(this IMappingExpression<TSource, TTarget> expression)
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);
            foreach (var prop in Mapper.GetAllTypeMaps().First(m => m.SourceType == sourceType && m.DestinationType == targetType).GetUnmappedPropertyNames())
            {
                expression.ForMember(prop, opt => opt.Ignore());
            }
            return expression;
        }

        #endregion

        #region Stored Procedure Extensions

        public static void SkipNextResult(this IDataReader reader, int skip)
        {
            for (var i = 0; i < skip; i++)
                reader.NextResult();
        }

        public static List<T> MapTo<T>(this IDataReader reader) where T : class
        {
            var list = new List<T>();
            T obj = default(T);
            while (reader.Read())
            {
                obj = Activator.CreateInstance<T>();

                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    object attrs = prop.GetCustomAttribute(typeof(IgnoreDataMappingAttribute));
                    if (attrs == null && !object.Equals(reader[prop.Name], DBNull.Value))                   
                        prop.SetValue(obj, reader[prop.Name], null);
                }
                list.Add(obj);
            }
            return list;
        }

        public static List<T> MapTo<T>(this IDataReader reader, string filedName) where T : struct
        {
            if (!typeof(T).IsPrimitive)
                throw new Exception("Type is not Primitive type");

            var list = new List<T>();
            while (reader.Read())
                list.Add((T)reader[filedName]);

            return list;
        }

        public static bool IsNotNullOrEmpty(this IEnumerable<string> property)
        {
            return (property != null && property.Any() && !string.IsNullOrEmpty(property.First()));
        }

        public static bool IsNotNullOrEmpty(this IEnumerable<int> property)
        {
            return (property != null && property.Any() && property.First() != 0);
        }

        public static string ToParameter(this IEnumerable<string> property)
        {
            return string.Join(",", property.Where(m => !string.IsNullOrEmpty(m)));
        }

        public static string ToParameter(this IEnumerable<int> property)
        {
            return string.Join(",", property.Where(m => m != 0));
        }

        #endregion
    }
}
