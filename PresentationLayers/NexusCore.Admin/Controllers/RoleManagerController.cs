using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NexusCore.Admin.UILogic.Adapter.ErrorHandlers;
using NexusCore.Admin.UILogic.ViewModels.ControlPanel;
using NexusCore.Admin.UILogic.ViewModels.Memberships;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Services.MembershipServices;

namespace NexusCore.Admin.Controllers
{
    [Authorize]
    public class RoleManagerController : BaseController
    {

        private readonly IMembershipService _membership;

        public RoleManagerController(IMembershipService membership)
        {
            _membership = membership;
        }

        // List Roles
        // GET: RoleManager
        public ActionResult Index()
        {
            GetInfoBox();
            PageInfo.Title = "Role Manager";
            PageInfo.MetaData.Title = "Role Manager";
            PageInfo.Angular = new GeneralPage.AngularJs
            {
                IsEnabled = true,
                Controller = new KeyValuePair<string, string>("roleManager", "roleManagerController"),
                HasInit = true,
                Init = new KeyValuePair<string, string>("init", "")
            };
            return View();
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            CreateRolePageSetting();
            var model = new CreateRoleViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                _membership.CreateRole(model.Role);

                if (ErrorAdapter.ModelState.IsValid)
                {
                    var messages = new GeneralPage.Message();
                    messages.AddWarningFromErrorAdapter();

                    messages.MessageDetails.Add(new GeneralPage.Message.MessageDetail
                    {
                        Level = GeneralPage.MessageType.Success,
                        Title = "Success",
                        Text = string.Format("A new role ({0}) has been created.", model.Role.RoleName)
                    });

                    TempData["InfoBox"] = messages;
                    return RedirectToAction("Index");
                }

                ModelState.AddFromErrorAdapter();
            }

            CreateRolePageSetting();
            return View(model);
        }

        private void CreateRolePageSetting()
        {
            PageInfo.Title = "Create New Role";
            PageInfo.MetaData.Title = "Create New Role";
            PageInfo.Angular = new GeneralPage.AngularJs
            {
                IsEnabled = false,
            };                        
        }

        [HttpGet]
        public ActionResult EditRole(Guid id)
        {
            var model = new EditRoleViewModel();
            model.InitData(_membership, id);
            EditRolePageSetting(model.Role.RoleName);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                _membership.UpdateRole(model.Role);

                if (ErrorAdapter.ModelState.IsValid)
                {
                    var messages = new GeneralPage.Message();
                    messages.AddWarningFromErrorAdapter();

                    messages.MessageDetails.Add(new GeneralPage.Message.MessageDetail
                    {
                        Level = GeneralPage.MessageType.Success,
                        Title = "Success",
                        Text = string.Format("User ({0}) information has been updated.", model.Role.RoleName)
                    });

                    TempData["InfoBox"] = messages;
                    return RedirectToAction("Index");
                }

                ModelState.AddFromErrorAdapter();
            }

            EditRolePageSetting(model.Role.RoleName);
            return View(model);
        }

        private void EditRolePageSetting(string roleName)
        {
            PageInfo.Title = string.Format("Editing Role {0}", roleName);
            PageInfo.MetaData.Title = string.Format("Editing Role {0}", roleName);
            PageInfo.Angular = new GeneralPage.AngularJs
            {
                IsEnabled = false,
            };
        }

        [HttpPost]
        public JsonResult GetRoleList(RoleSearchFilter searchFilter)
        {
            return Json(_membership.GetRoles(searchFilter), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteRole(Guid roleId)
        {
            _membership.DeleteRole(roleId);
            if (!ErrorAdapter.ModelState.IsValid)
                return Json(Response.ReturnError());
            
            return Json("Success");
        }
    }
}