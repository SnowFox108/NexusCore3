using System;
using System.Web.Mvc;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Data.Models.Websites;

namespace NexusCore.Admin.Controllers.WebServices
{
    public class ModelBuilderController : Controller
    {
        #region Filters

        [HttpGet]
        public JsonResult ClientSearchFilter()
        {
            return Json(new ClientSearchFilter(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult RoleSearchFilter()
        {
            return Json(new RoleSearchFilter
            {
                RoleName = ""
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult UserSearchFilter()
        {
            return Json(new UserSearchFilter
            {
                Title = "",
                FirstName = "",
                LastName = ""
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult WebsiteSearchFilter()
        {
            return Json(new WebsiteSearchFilter
            {
                ClientId = Guid.Empty,
                FriendlyId = "",
                Name = "",
                DomainName = "",
            }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Models

        [HttpGet]
        public JsonResult DomainViewModel()
        {
            return Json(new DomainModel(), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}