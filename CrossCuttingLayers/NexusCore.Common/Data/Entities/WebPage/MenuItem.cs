using System;
using System.ComponentModel.DataAnnotations;
using NexusCore.Common.Data.Models.Page;
using NexusCore.Infrasructure.Data;

namespace NexusCore.Common.Data.Entities.WebPage
{
    public class MenuItem : Entity
    {
        public Guid MenuId { get; set; }
        [StringLength(300)]
        public string Title { get; set; }
        [StringLength(500)]
        public string FriendlyUrl { get; set; }
        public WebPageType PageType { get; set; }
        public Guid ItemId { get; set; }

        public bool IsOnMenu { get; set; }
        public bool IsOnNavigator { get; set; }
        public bool IsOnSiteMap { get; set; }
        public bool IsPrivacyInherited { get; set; }
        public bool IsSeoInherited { get; set; }
        public bool IsSsl { get; set; }
    }
}
