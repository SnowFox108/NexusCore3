using NexusCore.Admin.UILogic.Adapter.ErrorHandlers;
using NexusCore.Admin.UILogic.Infrastructure;
using NexusCore.Admin.UILogic.ViewModels.ControlPanel;
using NexusCore.Admin.UILogic.ViewModels.Websites;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Models.Websites;
using NexusCore.Common.Services.ClientServices;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Common.Services.WebsiteServices;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NexusCore.Admin.Controllers
{
    public class WebsitesController : BaseController
    {
        private readonly IWebsiteService _websiteService;
        private readonly ISourceTreeService _sourceTreeService;
        private readonly IClientService _clientService;

        public WebsitesController(IWebsiteService website, ISourceTreeService sourceTreeService, IClientService clientService)
        {
            _websiteService = website;
            _sourceTreeService = sourceTreeService;
            _clientService = clientService;
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

        [HttpGet]
        public ActionResult CreateWebsite()
        {
            CreatePageSettings();
            var model = new CreateWebsiteViewModel();
            model.FormValue.Init(_sourceTreeService, _clientService);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateWebsite(CreateWebsiteViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Website.IsActive = true;
                model.Website.IsUnderMaintenance = false;
                model.Domain.IsActive = true;
                _websiteService.CreateWebsite(model.Website, model.Domain, model.ClientId);

                if (ErrorAdapter.ModelState.IsValid)
                {
                    TempData["InfoBox"] =
                        GeneralPageMessages.AddSuccess(string.Format("Website ({0}) has been created.",
                            model.Website.Name));
                    return RedirectToAction("Index");
                }
                ModelState.AddFromErrorAdapter();
            }

            // recreate page
            CreatePageSettings();
            model.FormValue.Init(_sourceTreeService, _clientService);
            return View(model);
        }

        private void CreatePageSettings()
        {
            PageInfo.Title = "Create New Website";
            PageInfo.TitleDescription = "Create a new website for a client";

            PageInfo.MetaData.Title = "Create New Website";
        }

        [HttpGet]
        public ActionResult EditWebsite(Guid websiteId)
        {
            var model = new EditWebsiteViewModel();
            model.InitData(_websiteService, _clientService, websiteId);
            EditPageSettings(model.Website.Name);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditWebsite(EditWebsiteViewModel model)
        {
            if (ModelState.IsValid)
            {
                _websiteService.UpdateWebsite(model.Website);

                if (ErrorAdapter.ModelState.IsValid)
                {
                    TempData["InfoBox"] = GeneralPageMessages.AddSuccess(string.Format("Website ({0}) information has been updated.", model.Website.Name));
                    return RedirectToAction("Index");                    
                }

                ModelState.AddFromErrorAdapter();
            }

            EditPageSettings(model.Website.Name);
            return View();
        }

        private void EditPageSettings(string websiteName)
        {
            PageInfo.Title = string.Format("Editing Website {0}", websiteName);
            PageInfo.TitleDescription = "Website basic information";

            PageInfo.MetaData.Title = string.Format("Editing Client {0}", websiteName);            
        }

        [HttpPost]
        public JsonResult GetWebsiteList(WebsiteSearchFilter searchFilter)
        {
            return Json(_websiteService.GetWebsites(searchFilter), JsonRequestBehavior.AllowGet);
        }
    }
}