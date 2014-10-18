using System.Collections.Generic;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.WebPage
{
    public class WebPage : TrackableEntity
    {
        public string Name { get; set; }
        public bool IsLayout { get; set; }

        public IEnumerable<PageControl> PageControls { get; set; }
    }
}
