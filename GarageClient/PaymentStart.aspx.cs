using System;
using Denion.WebService.VerwijsIndex;
using System.Configuration;

namespace GarageClient
{
    public partial class PaymentStart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            request.Data = new PaymentStartRequest();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                VerwijsIndexClient clnt = Service.PaymentClient(ConfigurationManager.AppSettings["VerwijsIndexURL"]);
                PaymentStartRequest req = request.Values as PaymentStartRequest;
                PaymentStartResponse res = clnt.PaymentStart(req);
                response.Data = res;
            }
            catch (Exception ex)
            {
                response.Data = ex;
            }
        }
    }
}