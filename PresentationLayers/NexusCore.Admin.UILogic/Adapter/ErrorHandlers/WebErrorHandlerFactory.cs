using System.Web;
using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Infrasructure.Adapter.ErrorHandlers;

namespace NexusCore.Admin.UILogic.Adapter.ErrorHandlers
{
     public class WebErrorHandlerFactory : IErrorHandlerFactory
    {
         public IErrorHandler Create()
         {
             return (HttpContext.Current.Items["ErrorHandler"] ?? (HttpContext.Current.Items["ErrorHandler"] = new SimpleErrorHandler())) as SimpleErrorHandler; 
         }
    }
}
