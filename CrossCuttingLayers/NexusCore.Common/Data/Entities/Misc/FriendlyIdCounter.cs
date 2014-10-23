using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.Misc
{
    public class FriendlyIdCounter: Entity
    {
        public string Prefix { get; set; }
        public int Counter { get; set; }
        public string Suffix { get; set; }
    }
}
