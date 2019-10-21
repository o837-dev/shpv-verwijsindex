using Denion.WebService.VerwijsIndex;
using System;
using System.Configuration;

namespace Denion.Web.ProviderClient
{
    public partial class ActivateAuthorisation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            request.Data = new ActivateAuthorisationRequest();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                WebService.VerwijsIndex.ProviderClient clnt = Service.LinkClient(ConfigurationManager.AppSettings["ProviderServiceURL"]);
                ActivateAuthorisationRequest req = request.Values as ActivateAuthorisationRequest;
                ActivateAuthorisationResponse res = clnt.ActivateAuthorisation(req);
                response.Data = res;
            }
            catch (Exception ex)
            {
                response.Data = ex;
            }
        }
    }
}