using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Denion.WebService.Database;
using Denion.WebService.Cryptography;
using Denion.WebService.VerwijsIndex;

namespace Denion.WebService.Beheer
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnfilter_Click(object sender, EventArgs e)
        {
            string VechicleId = txtWhere.Text.StripVehicleId();

            using (SqlCommand cmd = new SqlCommand("select * from AUTHORISATION where VEHICLEID=@VEHICLEID AND STARTDATE > DATEADD(DAY, -90, CURRENT_TIMESTAMP)"))
            {
                
                cmd.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Rijndael.Encrypt(VechicleId);

                DataTable dt = Database.Database.ExecuteQuery(cmd);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["VEHICLEID"] = Rijndael.Decrypt(dt.Rows[i]["VEHICLEID"].ToString());
                    }
                    grd1.DataSource = dt;
                }
                else
                {
                    DataView dv = new DataView(dt);
                    dv.AddNew();
                    grd1.DataSource = dv;
                }
                lblGrd1.Text = "Authorisation";
                grd1.DataBind();
            }

            using (SqlCommand cmd = new SqlCommand("select * from LINK where VEHICLEID=@VEHICLEID AND (STARTDATE > DATEADD(DAY, -90, CURRENT_TIMESTAMP) OR ENDDATE > DATEADD(DAY, -90, CURRENT_TIMESTAMP))"))
            {
                cmd.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Rijndael.Encrypt(VechicleId);

                DataTable dt = Database.Database.ExecuteQuery(cmd);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["VEHICLEID"] = Rijndael.Decrypt(dt.Rows[i]["VEHICLEID"].ToString());
                    }
                    grd2.DataSource = dt;
                }
                else
                {
                    DataView dv = new DataView(dt);
                    dv.AddNew();
                    grd2.DataSource = dv;
                }
                lblGrd2.Text = "Link";
                grd2.DataBind();
            }
        }
    }
}