using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexusCore.Admin.UILogic.Adapter.ErrorHandlers;
using NexusCore.Admin.UILogic.ViewModels.ControlPanel;
using NexusCore.Admin.UILogic.ViewModels.Memberships;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Common.Adapter.Language;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Common.Services.SourceTreeServices;
using NexusCore.Common.Services.WebsiteServices;
using NexusCore.Infrasructure.Models.Enums;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Admin.Controllers
{
    [Authorize]
    public class UserManagerController : BaseController
    {
        private readonly IAuthenticationManager _userManager;
        private readonly IMembershipService _membership;
        private readonly ISourceTreeService _sourceTree;
        private readonly IWebsitePrimitive _website;

        public UserManagerController(IAuthenticationManager userManager, IMembershipService membership, ISourceTreeService sourceTreeService, IWebsitePrimitive websiteService)
        {
            _membership = membership;
            _userManager = userManager;
            _sourceTree = sourceTreeService;
            _website = websiteService;
        }

        // List Users
        // GET: UserManager
        public ActionResult Index()
        {
            GetInfoBox();
            PageInfo.Title = "User Manager";
            PageInfo.Angular = new GeneralPage.AngularJs
            {
                IsEnabled = true,
                Controller = new KeyValuePair<string, string>("userManager", "userManagerController"),
                HasInit = true,
                Init = new KeyValuePair<string,string>("init", "")
            };
            return View();
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            CreateUserPageSetting();
            var model = new CreateUserViewModel();
            model.FormValue.Init(_sourceTree, _website);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.IsUserExist(model.User.Email))
                    ModelState.AddModelError("User.Email", LogCodeText.GetString(LogCode.WarningUserEmailAlreadyExist));

                if (ModelState.IsValid)
                {
                    _membership.RegisterNewUser(
                        model.RegistedWebsiteId, model.User.Title, model.User.UserName, model.User.Email,
                        model.User.FirstName,
                        model.User.LastName, model.User.PhoneNumber);

                    if (ErrorAdapter.ModelState.IsValid)
                    {

                        TempData["InfoBox"] = new GeneralPage.Message
                        {
                            HasMessage = true,
                            Level = GeneralPage.MessageType.Success,
                            Title = "Success",
                            Text = string.Format("A new user ({0}) has been created.", model.User.UserName)
                        };

                        return RedirectToAction("Index");
                    }

                    ModelState.AddFromErrorAdapter();
                }
            }

            CreateUserPageSetting();
            model.FormValue.Init(_sourceTree, _website);
            return View(model);
        }

        private void CreateUserPageSetting()
        {
            PageInfo.Title = "Create New User";
            PageInfo.TitleDescription = "User will receive an email to active their account and set password.";
            PageInfo.Angular = new GeneralPage.AngularJs
            {
                IsEnabled = false,
            };            
        }

        [HttpGet]
        public ActionResult EditUser(Guid id)
        {
            var model = new EditUserViewModel();
            model.InitData(_membership, id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                _membership.UpdateUser(model.User);

                if (ErrorAdapter.ModelState.IsValid)
                {
                    TempData["InfoBox"] = new GeneralPage.Message
                    {
                        HasMessage = true,
                        Level = GeneralPage.MessageType.Success,
                        Title = "Success",
                        Text = string.Format("User ({0}) information has been updated.", model.User.UserName)
                    };

                    return RedirectToAction("Index");
                }

                ModelState.AddFromErrorAdapter();
            }

            model.FormValue.Init(model.User.Title);
            return View(model);
        }

        [HttpPost]
        public JsonResult GetUserList(UserSearchFilter searchFilter)
        {
            return Json(_membership.GetUsers(searchFilter), JsonRequestBehavior.AllowGet);
        }
    }
}