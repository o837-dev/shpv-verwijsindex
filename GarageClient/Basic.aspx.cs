using System;
using Denion.WebService.VerwijsIndex;
using System.Configuration;

namespace GarageClient
{
    public partial class Basic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double dbl; DateTime dt;

            VerwijsIndexClient clnt = Service.PaymentClient(ConfigurationManager.AppSettings["VerwijsIndexURL"]);
            PaymentStartRequest req = new PaymentStartRequest();
            PaymentStartResponse res = null;

            req.AccessId = txtAccessId.Text;
            double.TryParse(txtAmount.Text, out dbl);
            req.Amount = dbl;

            req.AreaId = txtAreaId.Text;
            req.AreaManagerId = txtAreaManagerId.Text;
            req.CountryCode = txtCountryCode.Text;
            req.Token = txtReqToken.Text;
            req.TokenType = txtReqTokenType.Text;

            DateTime.TryParse(txtStartDateTime.Text, out dt);
            req.EndDateTime = dt;

            DateTime.TryParse(txtStartDateTime.Text, out dt);
            req.StartDateTime = dt;

            double.TryParse(txtVAT.Text, out dbl);
            req.VAT = dbl;
            req.VehicleId = txtVehicleId.Text;
            req.VehicleIdType = txtVehicleIdType.Text;
            res = clnt.PaymentStart(req);

            txtProviderId.Text = res.ProviderId;
            txtPaymentAuthorisationId.Text = res.PaymentAuthorisationId;
            txtAuthorisationMaxAmount.Text = res.AuthorisationMaxAmount.ToString();
            txtAuthorisationValidUntil.Text = res.AuthorisationValidUntil.ToString();
            txtRemarkId.Text = res.RemarkId;
            txtRemark.Text = res.Remark;
            txtResToken.Text = res.Token;
            txtResTokenType.Text =  res.TokenType;
        }
    }
}