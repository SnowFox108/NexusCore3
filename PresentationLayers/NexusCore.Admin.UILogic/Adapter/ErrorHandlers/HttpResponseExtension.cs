using NexusCore.Common.Adapter.ErrorHandlers;
using NexusCore.Infrasructure.Adapter.ErrorHandlers;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace NexusCore.Admin.UILogic.Adapter.ErrorHandlers
{
    public static class HttpResponseExtension
    {
        public static object Result(this HttpResponseBase response)
        {
            if (ErrorAdapter.ModelState.IsValid)
                return "Success";
            return ReturnError(response);
        }

        private static IEnumerable<IErrorModel> ReturnError(HttpResponseBase response)
        {
            response.StatusCode = (int) HttpStatusCode.BadRequest;
            return ErrorAdapter.ModelState.Errors;
        }
    }
}
