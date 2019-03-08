using Denion.WebService.Cryptography;
using Denion.WebService.Database;
using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

namespace Denion.Web.ProviderClient
{
    public partial class Cancel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            lblTable.Text = "Open Authorizations";
            using (SqlCommand cmd = new SqlCommand(
                " Select [REQUESTID], [AREAMANAGERID], [AREAID], [VEHICLEID], [COUNTRYCODE], [VEHICLEIDTYPE], [PROVIDERID], [AUTHORISATIONID] as [PAYMENTAUTHORISATIONID] " +
                " from Authorisation a " +
                " where a.SETTLED=@SETTLED"))
            {
                cmd.Parameters.Add("@SETTLED", SqlDbType.Bit).Value = false;
                cmd.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 100).Value = "3";

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Filter"]))
                {
                    lblTable.Text += "(Filter applied)";
                    cmd.CommandText += ConfigurationManager.AppSettings["Filter"];
                }
                DataTable dt = Database.ExecuteQuery(cmd);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["VEHICLEID"] = Rijndael.Decrypt(dt.Rows[i]["VEHICLEID"].ToString());
                    }
                    grd.DataSource = dt;
                }
                else
                {
                    DataView dv = new DataView(dt);
                    dv.AddNew();
                    grd.DataSource = dv;
                }
                grd.DataBind();
            }
        }

        private void RefreshPage()
        {
            // prevents the message on page refresh
            Response.Redirect(Request.RawUrl);
        }

        private Dictionary<string, string> ValuesFromRow(GridViewRow row)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < grd.Columns.Count; i++)
            {
                string key = grd.Columns[i].HeaderText;
                string value = HttpUtility.HtmlDecode(row.Cells[i].Text).Trim();
                if (!string.IsNullOrEmpty(key))
                    dic.Add(key, value);
            }
            return dic;
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Annuleren")
            {
                int idx = int.Parse(e.CommandArgument.ToString());
                Dictionary<string, string> dic = ValuesFromRow(grd.Rows[idx]);

                CancelAuthorisationRequest req = new CancelAuthorisationRequest();

                req.PaymentAuthorisationId = long.Parse(dic["PAYMENTAUTHORISATIONID"]);
                req.ProviderId = dic["PROVIDERID"];
                req.VehicleId = dic["VEHICLEID"];
                req.CountryCode = dic["COUNTRYCODE"];
                req.VehicleIdType = dic["VEHICLEIDTYPE"];
                req.AreaManagerId = dic["AREAMANAGERID"];
                req.AreaId = dic["AREAID"];
                req.CancelDateTime = DateTime.Now;

                WebService.VerwijsIndex.ProviderClient clnt = Service.LinkClient(ConfigurationManager.AppSettings["ProviderServiceURL"]);
                CancelAuthorisationResponse res = clnt.CancelAuthorisation(req);
                lblErr.Text += "Remark: " + res.Remark + "<br />";
            }
        }
    }
}