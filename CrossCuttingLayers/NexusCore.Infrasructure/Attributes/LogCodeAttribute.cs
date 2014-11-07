using System;
using NexusCore.Infrasructure.Models.Enums;

namespace NexusCore.Infrasructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StoreInLogAttribute : Attribute
    {
        public TaskCategory Category { get; set; }
        public LogLevel Level { get; set; }
        public bool IsLogged { get; set; }

        public StoreInLogAttribute(bool isLogged = false, TaskCategory category = TaskCategory.None, LogLevel level = LogLevel.Debug)
        {
            Category = category;
            Level = level;
            IsLogged = isLogged;
        }
    }
}
