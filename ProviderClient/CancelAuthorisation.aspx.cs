using Denion.WebService.VerwijsIndex;
using System;
using System.Configuration;

namespace Denion.Web.ProviderClient
{
    public partial class CancelAuthorisation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            request.Data = new CancelAuthorisationRequest();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                WebService.VerwijsIndex.ProviderClient clnt = Service.LinkClient(ConfigurationManager.AppSettings["ProviderServiceURL"]);
                CancelAuthorisationRequest req = request.Values as CancelAuthorisationRequest;
                CancelAuthorisationResponse res = clnt.CancelAuthorisation(req);
                response.Data = res;
            }
            catch (Exception ex)
            {
                response.Data = ex;
            }
        }
    }
}