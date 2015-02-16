using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexusCore.Admin.UILogic.Adapter.ErrorHandlers;
using NexusCore.Admin.UILogic.ViewModels.Clients;
using NexusCore.Admin.UILogic.ViewModels.ControlPanel;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Services.ClientServices;

namespace NexusCore.Admin.Controllers
{
    public class ClientsController : BaseController
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: Clients
        public ActionResult Index()
        {
            GetInfoBox();
            PageInfo.Title = "Client Manager";
            PageInfo.MetaData.Title = "Client Manager";
            PageInfo.Angular = new GeneralPage.AngularJs
            {
                IsEnabled = true,
                Controller = new KeyValuePair<string, string>("client", "clientController"),
                HasInit = true,
                Init = new KeyValuePair<string, string>("init", "")
            };
            return View();
        }

        [HttpGet]
        public ActionResult CreateClient()
        {
            CreateClientPageSetting();
            var model = new CreateClientViewModel();
            model.FormValue.Init();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateClient(CreateClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                _clientService.CreateClient(model.Client, model.ClientDepartment);

                if (ErrorAdapter.ModelState.IsValid)
                {
                    var messages = new GeneralPage.Message();
                    messages.AddWarningFromErrorAdapter();

                    messages.MessageDetails.Add(new GeneralPage.Message.MessageDetail
                    {
                        Level = GeneralPage.MessageType.Success,
                        Title = "Success",
                        Text = string.Format("A new client ({0}) has been created.", model.Client.Name)
                    });

                    TempData["InfoBox"] = messages;
                    return RedirectToAction("Index");
                }
                ModelState.AddFromErrorAdapter();
            }

            // recreate page
            CreateClientPageSetting();
            model.FormValue.Init();
            return View(model);
        }

        private void CreateClientPageSetting()
        {
            PageInfo.Title = "Create New Client";
            PageInfo.TitleDescription = "Create a new client and their primary address.";

            PageInfo.MetaData.Title = "Create New Client";
        }

        [HttpPost]
        public JsonResult GetClientList(ClientSearchFilter searchFilter)
        {
            return Json(_clientService.GetClients(searchFilter), JsonRequestBehavior.AllowGet);
        }
    }
}