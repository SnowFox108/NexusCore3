using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;

namespace NexusCore.UILogic.ViewEngine
{
    public class MvcViewEngine : RazorViewEngine, IViewEngine
    {
        public MvcViewEngine()
        {
            // load customer view engine path
            var paths = GetPaths().ToArray();
            ViewLocationFormats = paths;
            MasterLocationFormats = paths;
            PartialViewLocationFormats = paths;
        }

        private IEnumerable<string> GetPaths(IEnumerable<string> paths = null)
        {
            // default paths
            var defaultPaths = new string[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{1}/{0}.cshtml",
                "~/Websites/Tempaltes/{1}/{0}.cshtml"
            };

            foreach (var path in defaultPaths)
            {
                yield return path;
            }

            // custom paths
            if (paths == null) yield break;
            foreach (var path in paths)
            {
                yield return path;
            }
        }
    }
}
