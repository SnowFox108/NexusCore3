using System.Web.Mvc;
using NexusCore.Common.Data.Models.Memberships;

namespace NexusCore.Admin.Controllers.WebServices
{
    public class ModelBuilderController : Controller
    {
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
    }
}