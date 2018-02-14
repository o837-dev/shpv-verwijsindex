using System;
using Denion.WebService.VerwijsIndex;
using System.Configuration;

namespace GarageClient
{
    public partial class Check : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime dt;

            VerwijsIndexClient clnt = Service.PaymentClient(ConfigurationManager.AppSettings["VerwijsIndexURL"]);
            PaymentCheckRequest req = new PaymentCheckRequest();
            PaymentCheckResponse res = null;
            
            req.AreaId = txtAreaId.Text;
            req.AreaManagerId = txtAreaManagerId.Text;
            DateTime.TryParse(txtCheckDateTime.Text, out dt);
            req.CheckDateTime = dt;
            req.CountryCode = txtCountryCode.Text;
            req.Provider = txtProvider.Text;
            req.VehicleId = txtVehicleId.Text;
            req.VehicleIdType = txtVehicleIdType.Text;
            
            res = clnt.PaymentCheck(req);
            
            txtResAreaId.Text = res.AreaId;
            txtResGranted.Text = res.Granted.ToString();
            txtProviderId.Text = res.ProviderId;
            txtRemarkId.Text = res.RemarkId;
            txtRemark.Text = res.Remark;
            
        }
    }
}