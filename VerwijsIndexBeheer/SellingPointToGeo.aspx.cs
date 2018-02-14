using Denion.WebService.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Denion.WebService.Beheer
{
    public partial class SellingPointToGeo : System.Web.UI.Page
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
            lblTable.Text = "AreaToGeo";
            DataTable dt = Database.Database.ShowTable("AreaToGeo");
            if (dt != null && dt.Rows.Count > 0)
                grd.DataSource = dt;
            else
            {
                DataView dv = new DataView(dt);
                dv.AddNew();
                grd.DataSource = dv;
            }
            grd.DataBind();
        }

        private void RefreshPage()
        {
            //grd.EditIndex = -1;
            //LoadData();

            // prevents the message on page refresh
            Response.Redirect(Request.RawUrl);
        }

        protected void grd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grd.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void grd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Dictionary<string, string> dic = ValuesFromRow(grd.Rows[grd.EditIndex]);

            SqlCommand com = new SqlCommand("update AreaToGeo set AreaManagerId=@AreaManagerId, AreaId=@AreaId, Latitude=@Latitude, Longitude=@Longitude, SellingPointId=@SellingPointid where ID=@ID");
            ArgumentsFromDictionary(com, dic);
            
            com.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = grd.DataKeys[grd.EditIndex].Value;
            Database.Database.ExecuteScalar(com);

            RefreshPage();
        }

        protected void grd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            RefreshPage();
        }

        protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand com = new SqlCommand("delete from [AreaToGeo] where [ID]=@ID");
            com.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = grd.DataKeys[e.RowIndex].Value;
            Database.Database.ExecuteScalar(com);

            RefreshPage();
        }

        private Dictionary<string, string> ValuesFromRow(GridViewRow row)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < grd.Columns.Count; i++)
            {
                foreach (Control c in row.Cells[i].Controls)
                {
                    if (c.GetType() == typeof(TextBox))
                    {
                        if (grd.Columns[i].HeaderText.Equals("Latitude", StringComparison.OrdinalIgnoreCase) || grd.Columns[i].HeaderText.Equals("Longitude", StringComparison.OrdinalIgnoreCase))
                            dic.Add(grd.Columns[i].HeaderText, ((TextBox)c).Text.Replace(".", ","));
                        else
                            dic.Add(grd.Columns[i].HeaderText, ((TextBox)c).Text);
                    }
                }
            }
            return dic;
        }

        private void ArgumentsFromDictionary(SqlCommand com, Dictionary<string, string> dic)
        {
            if (dic.ContainsKey("AreaManagerId"))
                com.Parameters.Add("@AreaManagerId", System.Data.SqlDbType.NVarChar, 200).Value = dic["AreaManagerId"];
            if (dic.ContainsKey("AreaId"))
                com.Parameters.Add("@AreaId", System.Data.SqlDbType.NVarChar, 100).Value = dic["AreaId"];
            if (dic.ContainsKey("Latitude"))
            {
                if (!string.IsNullOrEmpty(dic["Latitude"]))
                    com.Parameters.Add("@Latitude", System.Data.SqlDbType.Float).Value = dic["Latitude"]; 
                else
                    com.Parameters.Add("@Latitude", System.Data.SqlDbType.Float).Value = DBNull.Value;
            }
            if (dic.ContainsKey("Longitude"))
            {
                if (!string.IsNullOrEmpty(dic["Longitude"]))
                    com.Parameters.Add("@Longitude", System.Data.SqlDbType.Float).Value = dic["Longitude"];
                else
                    com.Parameters.Add("@Longitude", System.Data.SqlDbType.Float).Value = DBNull.Value;
            }
            if (dic.ContainsKey("SellingPointId"))
                com.Parameters.Add("@SellingPointId", System.Data.SqlDbType.NVarChar, 100).Value = dic["SellingPointId"];
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Dictionary<string, string> dic = ValuesFromRow(grd.FooterRow);
                SqlCommand com = new SqlCommand("INSERT INTO AreaToGeo (AreaManagerId, AreaId, Latitude, Longitude, SellingPointId) values (@AreaManagerId, @AreaId, @Latitude, @Longitude, @SellingPointId)");
                ArgumentsFromDictionary(com, dic);

                Database.Database.ExecuteScalar(com);

                RefreshPage();
            }
        }

        protected string URL(object datarow)
        {
            string rv = string.Empty;
            try
            {
                DataRowView row = (DataRowView)datarow;
                object lat = row["Latitude"];
                object lon = row["Longitude"];

                if (lat != DBNull.Value && lon != DBNull.Value)
                {
                    string slat = lat.ToString();
                    string slon = lon.ToString();
                    if (!string.IsNullOrEmpty(slat) && !string.IsNullOrEmpty(slon))
                    {
                        float flat;
                        float flon;
                        float.TryParse(slat, out flat);
                        float.TryParse(slon, out flon);
                        rv = string.Format("<a target='_blank' href='http://maps.google.com/maps?q={0},{1}'><img src='/style/Earth.png' alt='Earth icon' title='Tonen in Google Maps'></a>", flat.ToString(System.Globalization.CultureInfo.InvariantCulture), flon.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (Exception)
            {
                // do nothing
            }
            return rv;
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object ID = grd.DataKeys[e.Row.RowIndex].Value;
                if (ID == DBNull.Value) e.Row.Visible = false;
            }
        }
    }
}