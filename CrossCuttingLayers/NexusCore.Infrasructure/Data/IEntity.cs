using System;

namespace NexusCore.Infrasructure.Data
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
