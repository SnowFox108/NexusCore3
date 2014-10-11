using System;
using System.Diagnostics;
using System.Web;

namespace NexusCore.Web.UILogic.Routing
{
    public class DomainHandler : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var context = application.Context;

            // check sub domain then push it to main
            var domain = context.Request.Url.Authority;
            Debug.WriteLine(domain);            
        }

        public void Dispose()
        {
            
        }
    }
}
