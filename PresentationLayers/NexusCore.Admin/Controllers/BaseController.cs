using System.Web.Mvc;
using System.Web.Routing;
using NexusCore.Admin.UILogic.ViewModels.ControlPanel;

namespace NexusCore.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected GeneralPage PageInfo;

        protected override void Initialize(RequestContext requestContext)
        {
            
            PageInfo = new GeneralPage
            {
                MetaData = new GeneralPage.Meta
                {
                    Title = "General Page",
                    Description = "General Page",
                    Keywords = "",
                    FavIcon = "~/favicon.ico"
                },
                PageClass = new GeneralPage.CssClass
                {
                    Body = ""
                },
                Angular = new GeneralPage.AngularJs
                {
                    IsEnabled = false
                },
                InfoBox = new GeneralPage.Message
                {
                    HasMessage = false
                },
                Title = "General Page",
                TitleDescription = ""                
            };

            ViewBag.PageInfo = PageInfo;

            base.Initialize(requestContext);
        }

        protected void GetInfoBox()
        {
            if (TempData["InfoBox"] != null)
            {
                PageInfo.InfoBox = (GeneralPage.Message)TempData["InfoBox"];
            }            
        }
    } 

}