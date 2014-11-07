using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Resources;

namespace NexusCore.Common.Data.Models.Websites
{
    public class DomainModel
    {
        public Guid WebsiteId { get; set; }
        [Required(ErrorMessageResourceType = typeof (DataAnnotationText), ErrorMessageResourceName = "DomainRequiredName")]
        public Guid Name { get; set; }
        public bool IsActive { get; set; }

    }
}
