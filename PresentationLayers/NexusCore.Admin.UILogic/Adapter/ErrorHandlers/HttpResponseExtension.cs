using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Infrasructure.Adapter.ErrorHandlers;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace NexusCore.Admin.UILogic.Adapter.ErrorHandlers
{
    public static class HttpResponseExtension
    {
        public static IEnumerable<IErrorModel> ReturnError(this HttpResponseBase response)
        {
            response.StatusCode = (int) HttpStatusCode.BadRequest;
            return ErrorAdapter.ModelState.Errors;
        }
    }
}
