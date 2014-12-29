using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexusCore.Admin.UILogic.ViewModels.ControlPanel;
using NexusCore.Admin.UILogic.ViewModels.Memberships;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Infrasructure.Security;

namespace NexusCore.Admin.Controllers
{
    [Authorize]
    public class UserManagerController : BaseController
    {
        private readonly IAuthenticationManager _userManager;
        private readonly IMembershipService _membership;

        public UserManagerController(IMembershipService membership, IAuthenticationManager userManager)
        {
            _membership = membership;
            _userManager = userManager;
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
            return View(new CreateUserViewModel());
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.IsUserExist(model.User.Email))
                    ModelState.AddModelError("User.Email", "User already exist in system");
                //// TODO get default websiteId
                //_membership.RegisterNewUser(
                //    new Guid(), model.User.Title, model.User.UserName, model.User.Email, model.User.FirstName,
                //    model.User.LastName, model.User.PhoneNumber);
                TempData["InfoBox"] = new GeneralPage.Message
                {
                    HasMessage = true,
                    Level = GeneralPage.MessageType.Success,
                    Title = "Success",
                    Text = "A new user has been created."
                };
                return RedirectToAction("Index");
            }

            CreateUserPageSetting();
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

        [HttpPost]
        public JsonResult GetUserList(UserSearchFilter searchFilter)
        {
            return Json(_membership.GetUsers(searchFilter), JsonRequestBehavior.AllowGet);
        }
    }
}