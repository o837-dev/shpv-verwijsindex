using Denion.WebService.VerwijsIndex;
using System;
using System.Configuration;

namespace Denion.Web.ProviderClient
{
    public partial class EnrollPSRight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            request.Data = new PSRightEnrollRequestData();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrationClient clnt = Service.NPRLikeClient(ConfigurationManager.AppSettings["NPRProviderServiceURL"]);
                PSRightEnrollRequestData req = request.Values as PSRightEnrollRequestData;
                PSRightEnrollResponseError err = null;
                PSRightEnrollResponseData res = clnt.EnrollPSRight(null, req, out err);

                if (err != null)
                    response.Data = err;
                else
                    response.Data = res;
            }
            catch(Exception ex)
            {
                response.Data = ex;
            }
        }
    }
}