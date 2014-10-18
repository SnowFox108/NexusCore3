using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NexusCore.Admin.Controllers
{
    public class InstallationController : Controller
    {
        public InstallationController()
        {
            
        }
        // GET: Installation
        public ActionResult Index()
        {
            return View();
        }
    }
}