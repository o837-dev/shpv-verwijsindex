using Denion.WebService.VerwijsIndex;
using System;
using System.Configuration;

namespace GarageClient
{
    public partial class PaymentEnd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            request.Data = new PaymentEndRequest();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                VerwijsIndexClient clnt = Service.PaymentClient(ConfigurationManager.AppSettings["VerwijsIndexURL"]);
                PaymentEndRequest req = request.Values as PaymentEndRequest;
                PaymentEndResponse res = clnt.PaymentEnd(req);
                response.Data = res;
            }
            catch (Exception ex)
            {
                response.Data = ex;
            }
        }
    }
}