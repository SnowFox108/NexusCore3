using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using NexusCore.Infrasructure.Attributes;

namespace NexusCore.Common.Data.Infrastructure.Extensions
{
    public static class DbStoredProcedureExtensions
    {

        public static void SkipNextResult(this IDataReader reader, int skip)
        {
            for (int i = 0; i < skip; i++)
                reader.NextResult();
        }

        public static List<T> MapTo<T>(this IDataReader reader) where T: class 
        {
            var list = new List<T>();
            var obj = default(T);
            while (reader.Read())
            {
                obj = Activator.CreateInstance<T>();

                foreach (var prop in obj.GetType().GetProperties())
                {
                    object attrs = prop.GetCustomAttribute(typeof(IgnoreDataMappingAttribute));
                    if (attrs == null && !object.Equals(reader[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, reader[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public static List<T> MapTo<T>(this IDataReader reader, string filedName)
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
    }
}
