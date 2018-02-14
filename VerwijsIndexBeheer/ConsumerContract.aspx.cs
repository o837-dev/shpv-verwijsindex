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
    public partial class ConsumerContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData(string.Empty);
            }
        }
        
        public DataTable GetAreaManagers()
        {
            DataTable dt = Database.Database.ExecuteQuery("Select distinct c.AREAMANAGERID as ID, am.DESCRIPTION from ConsumerContract as c join AreaManager as am on c.AREAMANAGERID = am.ID");
            DataRow dr = dt.NewRow();
            dr["ID"] = "-";
            dr["DESCRIPTION"] = "-";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        private void LoadData(string filter)
        {
            string selectedValue = null;
            if (grd.HeaderRow != null)
            {
                Control ctrl = grd.HeaderRow.FindControl("fltrAREAMANAGERID");
                if (ctrl != null)
                {
                    DropDownList DDAreaManager = (DropDownList)ctrl;
                    selectedValue = DDAreaManager.SelectedValue;
                }
            }

            lblTable.Text = "ConsumerContract";
            DataView dv = new DataView(Database.Database.ExecuteQuery("Select * from ConsumerContract order by AreaManagerId, AreaId"));
            if (!string.IsNullOrEmpty(filter))
                dv.RowFilter = filter;

            if (dv.Count == 0)
            {
                dv.RowFilter = null;
                if (!String.IsNullOrEmpty(filter))
                    lblErr.Text = "Geen resultaat bij zoekcriteria";
                else
                {
                    //dv.AddNew();
                    //                  [ID], [AREAMANAGERID], [AREAID], [CONSUMERID], [STARTDATE], [ENDDATE]
                    dv.Table.Rows.Add(new object[] { null, null, null, null, DateTime.MinValue, DateTime.MinValue });

                }
            }
            grd.DataSource = dv;
            grd.DataBind();

            if (grd.HeaderRow != null)
            {
                Control ctrl = grd.HeaderRow.FindControl("fltrAREAMANAGERID");
                if (ctrl != null)
                {
                    DropDownList DDAreaManager = (DropDownList)ctrl;

                    DDAreaManager.DataSource = GetAreaManagers();
                    if (!string.IsNullOrEmpty(selectedValue))
                        DDAreaManager.SelectedValue = selectedValue;
                    DDAreaManager.DataBind();
                }
            }

            if (grd.FooterRow != null)
            {
                Control ctrl = grd.FooterRow.FindControl("consumerContractAREAMANAGERID");
                if (ctrl != null)
                {
                    DropDownList DDAreaManager = (DropDownList)ctrl;
                    DDAreaManager.DataSource = Database.Database.ShowTable("AreaManager");
                    DDAreaManager.DataBind();
                }
                ctrl = grd.FooterRow.FindControl("consumerContractCONSUMERID");
                if (ctrl != null)
                {
                    DropDownList DDConsumer = (DropDownList)ctrl;
                    DDConsumer.DataSource = Database.Database.ShowTable("Consumer");
                    DDConsumer.DataBind();
                }
            }
        }

        private void RefreshPage()
        {
            // prevents the message on page refresh
            Response.Redirect(Request.RawUrl);
        }

        protected void grd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grd.EditIndex = e.NewEditIndex;
            string filter = String.Empty;
            if (grd.HeaderRow != null)
            {
                Control ctrl = grd.HeaderRow.FindControl("fltrAREAMANAGERID");
                if (ctrl != null)
                {
                    DropDownList fltrAREAMANAGERID = (DropDownList)ctrl;
                    if (fltrAREAMANAGERID.SelectedValue != "-")
                    {
                        filter = "AREAMANAGERID = '" + fltrAREAMANAGERID.SelectedValue + "'";
                    }
                }
            }
            LoadData(filter);
        }

        protected void grd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Dictionary<string, object> dic = ValuesFromRow(grd.Rows[grd.EditIndex]);

            SqlCommand com = new SqlCommand("update CONSUMERCONTRACT set AREAMANAGERID=@AREAMANAGERID, AREAID=@AREAID, CONSUMERID=@CONSUMERID, STARTDATE=@STARTDATE, ENDDATE=@ENDDATE where ID=@ID");
            ArgumentsFromDictionary(com, dic);
            com.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = grd.DataKeys[grd.EditIndex].Value;

            Database.Database.ExecuteScalar(com);

            RefreshPage();
        }

        protected void grd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
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
                        dic.Add(grd.Columns[i].HeaderText, ((TextBox)c).Text);
                    }
                    else if (c.GetType() == typeof(DropDownList))
                    {
                        dic.Add(grd.Columns[i].HeaderText, ((DropDownList)c).SelectedValue);
                    }
                    else if (c.GetType() == typeof(CheckBox))
                    {
                        dic.Add(grd.Columns[i].HeaderText, ((CheckBox)c).Checked);
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
            if (dic.ContainsKey("AREAMANAGERID"))
                com.Parameters.Add("@AREAMANAGERID", System.Data.SqlDbType.NVarChar, 200).Value = dic["AREAMANAGERID"];
            if (dic.ContainsKey("AREAID"))
                com.Parameters.Add("@AREAID", System.Data.SqlDbType.NVarChar, 100).Value = dic["AREAID"];
            if (dic.ContainsKey("CONSUMERID"))
                com.Parameters.Add("@CONSUMERID", System.Data.SqlDbType.Int).Value = dic["CONSUMERID"];
            if (dic.ContainsKey("STARTDATE"))
                com.Parameters.Add("@STARTDATE", System.Data.SqlDbType.DateTime).Value = dic["STARTDATE"];
            if (dic.ContainsKey("ENDDATE"))
                com.Parameters.Add("@ENDDATE", System.Data.SqlDbType.DateTime).Value = dic["ENDDATE"];
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Dictionary<string, object> dic = ValuesFromRow(grd.FooterRow);

                SqlCommand com = new SqlCommand("insert into CONSUMERCONTRACT (AREAMANAGERID, AREAID, CONSUMERID, STARTDATE, ENDDATE) values (@AREAMANAGERID, @AREAID, @CONSUMERID, @STARTDATE, @ENDDATE)");
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
                if (ID == DBNull.Value)
                {
                    e.Row.Visible = false;
                }
                else
                {
                    DropDownList DDAreaManager = (DropDownList)e.Row.FindControl("consumerContractAREAMANAGERID");
                    DDAreaManager.DataSource = Database.Database.ShowTable("AreaManager");
                    DDAreaManager.SelectedValue = ((DataRowView)e.Row.DataItem).Row["AREAMANAGERID"].ToString();
                    DDAreaManager.DataBind();

                    DropDownList DDConsumer = (DropDownList)e.Row.FindControl("consumerContractCONSUMERID");
                    DDConsumer.DataSource = Database.Database.ShowTable("Consumer");
                    DDConsumer.SelectedValue = ((DataRowView)e.Row.DataItem).Row["CONSUMERID"].ToString();
                    DDConsumer.DataBind();
                }
            }
        }

        protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand com = new SqlCommand("delete from [ConsumerContract] where [ID]=@ID");

            com.Parameters.Add("@ID", System.Data.SqlDbType.NVarChar, 200).Value = grd.DataKeys[e.RowIndex].Value;
            Database.Database.ExecuteScalar(com);

            RefreshPage();
        }

        protected void fltrAREAMANAGERID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList fltrAREAMANAGERID = sender as DropDownList;
            string filter = String.Empty;
            if (fltrAREAMANAGERID.SelectedValue != "-")
            {
                filter = "AREAMANAGERID = '" + fltrAREAMANAGERID.SelectedValue + "'";
            }
            LoadData(filter);
        }

    }
}