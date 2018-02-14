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
    public partial class TestParkingFacility : System.Web.UI.Page
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
            lblTable.Text = "PMSsim";
            DataTable dt = Database.Database.ShowTable("TestConsumer");
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
            Dictionary<string, object> dic = ValuesFromRow(grd.Rows[grd.EditIndex]);

            SqlCommand com = new SqlCommand(@"
            UPDATE [TestConsumer]
               SET [VEHICLEID] = @VEHICLEID
                  ,[COUNTRYCODE] = @COUNTRYCODE
                  ,[VEHICLEIDTYPE] = @VEHICLEIDTYPE
                  ,[STARTDATETIME] = @STARTDATETIME
                  ,[ENDDATETIME] = @ENDDATETIME
                  ,[AREAMANAGERID] = @AREAMANAGERID
                  ,[AREAID] = @AREAID
                  ,[AMOUNT] = @AMOUNT
                  ,[VAT] = @VAT
             WHERE ID=@ID");
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
            SqlCommand com = new SqlCommand("delete from [TestConsumer] where [ID]=@ID");
            com.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = grd.DataKeys[e.RowIndex].Value;
            Database.Database.ExecuteScalar(com);

            RefreshPage();
        }

        private Dictionary<string, object> ValuesFromRow(GridViewRow row)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            for (int i = 0; i < grd.Columns.Count; i++)
            {
                foreach (Control c in row.Cells[i].Controls)
                {
                    if (c.GetType() == typeof(TextBox))
                    {
                        if (grd.Columns[i].HeaderText.Equals("VAT", StringComparison.OrdinalIgnoreCase) || grd.Columns[i].HeaderText.Equals("Amount", StringComparison.OrdinalIgnoreCase))
                            dic.Add(grd.Columns[i].HeaderText, ((TextBox)c).Text.Replace(".", ","));
                        else
                            dic.Add(grd.Columns[i].HeaderText, ((TextBox)c).Text);
                    }
                    else if (c.GetType().BaseType == typeof(Controls.TimePicker))
                    {
                        dic.Add(grd.Columns[i].HeaderText, ((Controls.TimePicker)c).Value);
                    }
                }
            }
            return dic;
        }

        private void ArgumentsFromDictionary(SqlCommand com, Dictionary<string, object> dic)
        {
            if (dic.ContainsKey("VEHICLEID"))
                com.Parameters.Add("@VEHICLEID", System.Data.SqlDbType.NVarChar, 100).Value = VerwijsIndex.Functions.StripVehicleId((string)dic["VEHICLEID"]);
            if (dic.ContainsKey("COUNTRYCODE"))
                com.Parameters.Add("@COUNTRYCODE", System.Data.SqlDbType.NVarChar, 10).Value = dic["COUNTRYCODE"];
            if (dic.ContainsKey("VEHICLEIDTYPE"))
                com.Parameters.Add("@VEHICLEIDTYPE", System.Data.SqlDbType.NVarChar, 50).Value = dic["VEHICLEIDTYPE"];
            if (dic.ContainsKey("STARTDATETIME") && (DateTime)dic["STARTDATETIME"] > DateTime.MinValue)
                com.Parameters.Add("@STARTDATETIME", System.Data.SqlDbType.DateTime).Value = dic["STARTDATETIME"];
            else
                com.Parameters.Add("@STARTDATETIME", System.Data.SqlDbType.DateTime).Value = DBNull.Value;
            if (dic.ContainsKey("ENDDATETIME") && (DateTime)dic["ENDDATETIME"] > DateTime.MinValue)
                com.Parameters.Add("@ENDDATETIME", System.Data.SqlDbType.DateTime).Value = dic["ENDDATETIME"];
            else
                com.Parameters.Add("@ENDDATETIME", System.Data.SqlDbType.DateTime).Value = DBNull.Value;
            if (dic.ContainsKey("AREAMANAGERID"))
                com.Parameters.Add("@AREAMANAGERID", System.Data.SqlDbType.NVarChar, 200).Value = dic["AREAMANAGERID"];
            if (dic.ContainsKey("AREAID"))
                com.Parameters.Add("@AREAID", System.Data.SqlDbType.NVarChar, 100).Value = dic["AREAID"];
            if (dic.ContainsKey("AMOUNT") && !String.IsNullOrEmpty((string)dic["AMOUNT"]))
                com.Parameters.Add("@AMOUNT", System.Data.SqlDbType.Decimal).Value = dic["AMOUNT"];
            else
                com.Parameters.Add("@AMOUNT", System.Data.SqlDbType.Decimal).Value = DBNull.Value;
            if (dic.ContainsKey("VAT") && !String.IsNullOrEmpty((string)dic["VAT"]))
                com.Parameters.Add("@VAT", System.Data.SqlDbType.Decimal).Value = dic["VAT"];
            else
                com.Parameters.Add("@VAT", System.Data.SqlDbType.Decimal).Value = DBNull.Value;

        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Dictionary<string, object> dic = ValuesFromRow(grd.FooterRow);
                SqlCommand com = new SqlCommand(@"
INSERT INTO [dbo].[TestConsumer]
           ([VEHICLEID]
           ,[COUNTRYCODE]
           ,[VEHICLEIDTYPE]
           ,[STARTDATETIME]
           ,[ENDDATETIME]
           ,[AREAMANAGERID]
           ,[AREAID]
           ,[AMOUNT]
           ,[VAT])
     VALUES
           (@VEHICLEID
           ,@COUNTRYCODE
           ,@VEHICLEIDTYPE
           ,@STARTDATETIME
           ,@ENDDATETIME
           ,@AREAMANAGERID
           ,@AREAID
           ,@AMOUNT
           ,@VAT)");
                ArgumentsFromDictionary(com, dic);

                Database.Database.ExecuteScalar(com);

                RefreshPage();
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object ID = grd.DataKeys[e.Row.RowIndex].Value;
                if (ID == DBNull.Value) e.Row.Visible = false;
            }
        }

        protected object EvalDateTime(object datarow, string parm)
        {
            DateTime rv = DateTime.MinValue;
            try
            {
                DataRowView row = (DataRowView)datarow;

                object dt = row[parm];
                if (dt != null && dt != DBNull.Value)
                {
                    rv = (DateTime)dt;
                }
            }
            catch (Exception)
            { }
            return rv;
        }
    }
}