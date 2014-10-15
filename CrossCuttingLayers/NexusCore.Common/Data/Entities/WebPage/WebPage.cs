using System;
using System.Collections.Generic;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.WebPage
{
    public class WebPage : Entity, ITrackable
    {
        public string Name { get; set; }
        public bool IsLayout { get; set; }

        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }

        public IEnumerable<PageControl> PageControls { get; set; }
    }
}
