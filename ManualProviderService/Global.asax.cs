using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Denion.WebService.VerwijsIndex;
using System.Xml;

namespace ManualProviderService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Dictionary<UniqueId, PaymentStartRequest> reqlist = new Dictionary<UniqueId, PaymentStartRequest>();
            Application["reqlist"] = reqlist;
            Dictionary<UniqueId, PaymentStartResponse> reslist = new Dictionary<UniqueId, PaymentStartResponse>();
            Application["reslist"] = reslist;

            //Dictionary<UniqueId, LinkRequest> llreqlist = new Dictionary<UniqueId, LinkRequest>();
            //Application["llreqlist"] = llreqlist;
            //Dictionary<UniqueId, LinkResponse> llreslist = new Dictionary<UniqueId, LinkResponse>();
            //Application["llreslist"] = llreslist;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}