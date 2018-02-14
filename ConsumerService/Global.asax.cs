using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;

namespace ConsumerService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Dictionary<UniqueId, CancelAuthorisationResponse> reslist = new Dictionary<UniqueId, CancelAuthorisationResponse>();
            Application["reslist"] = reslist;
            Dictionary<UniqueId, CancelAuthorisationRequest> reqlist = new Dictionary<UniqueId, CancelAuthorisationRequest>();
            Application["reqlist"] = reqlist;

            Dictionary<UniqueId, ActivateAuthorisationResponse> aareslist = new Dictionary<UniqueId, ActivateAuthorisationResponse>();
            Application["aareslist"] = aareslist;
            Dictionary<UniqueId, ActivateAuthorisationRequest> aareqlist = new Dictionary<UniqueId, ActivateAuthorisationRequest>();
            Application["aareqlist"] = aareqlist;
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