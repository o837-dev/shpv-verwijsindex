using System;
using Denion.WebService.VerwijsIndex;
using System.Configuration;

namespace GarageClient
{
    public partial class PaymentCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            request.Data = new PaymentCheckRequest();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                VerwijsIndexClient clnt = Service.PaymentClient(ConfigurationManager.AppSettings["VerwijsIndexURL"]);
                PaymentCheckRequest req = request.Values as PaymentCheckRequest;
                PaymentCheckResponse res = clnt.PaymentCheck(req);
                response.Data = res;
            }
            catch (Exception ex)
            {
                response.Data = ex;
            }
        }
    }
}