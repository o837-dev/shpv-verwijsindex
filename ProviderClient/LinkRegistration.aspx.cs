using Denion.WebService.VerwijsIndex;
using System;
using System.Configuration;

namespace Denion.Web.ProviderClient
{
    public partial class LinkRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            request.Data = new LinkRegistrationRequest();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                WebService.VerwijsIndex.ProviderClient clnt = Service.LinkClient(ConfigurationManager.AppSettings["ProviderServiceURL"]);
                LinkRegistrationRequest req = request.Values as LinkRegistrationRequest;
                LinkRegistrationResponse res = clnt.Registration(req);
                response.Data = res;
            }
            catch (Exception ex)
            {
                response.Data = ex;
            }
        }
    }
}
