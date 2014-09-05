using NexusCore.Infrasructure.Data;

namespace NexusCore.Infrasructure.Security.Models
{
    public interface IRole : IEntity
    {
        string RoleName { get; set; }
        string Description { get; set; }
    }
}
