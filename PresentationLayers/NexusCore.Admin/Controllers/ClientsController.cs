using NexusCore.Admin.UILogic.Adapter.ErrorHandlers;
using NexusCore.Admin.UILogic.Infrastructure;
using NexusCore.Admin.UILogic.ViewModels.Clients;
using NexusCore.Admin.UILogic.ViewModels.ControlPanel;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Models.Clients;
using NexusCore.Common.Services.ClientServices;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

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

        [HttpGet]
        public ActionResult EditClient(Guid id)
        {
            var model = new EditClientViewModel();
            model.InitData(_clientService, id);
            EditClientPageSetting(model.Client.Name);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditClient(EditClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                _clientService.UpdateClient(model.Client);

                if (ErrorAdapter.ModelState.IsValid)
                {
                    //var messages = new GeneralPage.Message();
                    //messages.AddWarningFromErrorAdapter();

                    //messages.MessageDetails.Add(new GeneralPage.Message.MessageDetail
                    //{
                    //    Level = GeneralPage.MessageType.Success,
                    //    Title = "Success",
                    //    Text = string.Format("User ({0}) information has been updated.", model.User.UserName)
                    //});

                    TempData["InfoBox"] = GeneralPageMessages.AddSuccess(string.Format("Client ({0}) information has been updated.", model.Client.Name));
                    return RedirectToAction("Index");
                }

                ModelState.AddFromErrorAdapter();
            }

            EditClientPageSetting(model.Client.Name);
            return View(model);

        }

        private void EditClientPageSetting(string clientName)
        {
            PageInfo.Title = string.Format("Editing Client {0}", clientName);
            PageInfo.TitleDescription = "Client basic information";

            PageInfo.MetaData.Title = string.Format("Editing Client {0}", clientName);            
        }

        [HttpPost]
        public JsonResult GetClientList(ClientSearchFilter searchFilter)
        {
            return Json(_clientService.GetClients(searchFilter), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteClient(Guid clientId)
        {
            _clientService.DeleteClient(clientId);
            return Json(Response.Result());
        }

    }
}