using Denion.WebService.VerwijsIndex;
using System;
using System.Configuration;

namespace Denion.Web.ProviderClient
{
    public partial class RevokePSRight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            request.Data = new PSRightRevokeRequestData();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrationClient clnt = Service.NPRLikeClient(ConfigurationManager.AppSettings["NPRProviderServiceURL"]);
                PSRightRevokeRequestData req = request.Values as PSRightRevokeRequestData;
                PSRightRevokeResponseError err = null;
                PSRightRevokeResponseData res = clnt.RevokePSRight(null, req, out err);

                if (err != null)
                    response.Data = err;
                else
                    response.Data = res;
            }
            catch (Exception ex)
            {
                response.Data = ex;
            }
        }
    }
}