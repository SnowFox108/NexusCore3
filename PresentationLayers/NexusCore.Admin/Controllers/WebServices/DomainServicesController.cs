using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexusCore.Admin.UILogic.Adapter.ErrorHandlers;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Models.Websites;
using NexusCore.Common.Services.WebsiteServices;

namespace NexusCore.Admin.Controllers.WebServices
{
    public class DomainServicesController : Controller
    {

        private readonly IWebsiteService _websieService;

        public DomainServicesController(IWebsiteService websieService)
        {
            this._websieService = websieService;
        }

        // GET: DomainServices
        [HttpGet]
        public JsonResult Index(Guid websiteId)
        {
            return Json(_websieService.GetDomains(websiteId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateDomain(DomainModel model)
        {
            _websieService.CreateDomain(model);
            return Json(Response.Result());
        }
    }
}