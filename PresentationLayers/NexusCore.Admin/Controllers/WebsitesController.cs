using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexusCore.Admin.UILogic.ViewModels.ControlPanel;
using NexusCore.Common.Data.Models.Websites;
using NexusCore.Common.Services.WebsiteServices;

namespace NexusCore.Admin.Controllers
{
    public class WebsitesController : BaseController
    {
        private readonly IWebsiteService _website;

        public WebsitesController(IWebsiteService website)
        {
            _website = website;
        }

        // GET: Websites
        public ActionResult Index()
        {
            GetInfoBox();
            PageInfo.Title = "Website Manager";
            PageInfo.MetaData.Title = "Website Manager";
            PageInfo.Angular = new GeneralPage.AngularJs
            {
                IsEnabled = true,
                Controller = new KeyValuePair<string, string>("website", "websiteController"),
                HasInit = true,
                Init = new KeyValuePair<string, string>("init", "")
            };
            return View();
        }

        public ActionResult CreateWebsite()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetWebsiteList(WebsiteSearchFilter searchFilter)
        {
            return Json(_website.GetWebsites(searchFilter), JsonRequestBehavior.AllowGet);
        }
    }
}