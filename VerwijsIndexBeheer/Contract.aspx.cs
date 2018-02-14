using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Denion.WebService.Database;
using System.Data.SqlClient;
using System.Data;

namespace Denion.WebService.Beheer
{
    public partial class Contract : System.Web.UI.Page
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
            DataTable dt = Database.Database.ExecuteQuery("Select distinct c.AREAMANAGERID as ID, am.DESCRIPTION from Contract as c join AreaManager as am on c.AREAMANAGERID = am.ID");
            DataRow dr = dt.NewRow();
            dr["ID"] = "-";
            dr["DESCRIPTION"] = "-";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        private DataTable GetProviders()
        {
            DataTable dt = Database.Database.ExecuteQuery("Select distinct convert(varchar, p.PID) as PID, p.DESCRIPTION from Contract as c join Provider as p on c.PROVIDERID2 = p.PID order by PID");
            DataRow dr = dt.NewRow();
            dr["PID"] = "-";
            dr["DESCRIPTION"] = "-";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        private void LoadData(string filter)
        {
            string selectedValue = null; string selectedValue2 = null;
            if (grd.HeaderRow != null)
            {
                Control ctrl = grd.HeaderRow.FindControl("fltrAREAMANAGERID");
                if (ctrl != null)
                {
                    DropDownList DDAreaManager = (DropDownList)ctrl;
                    selectedValue = DDAreaManager.SelectedValue;
                }
                Control ctrl2 = grd.HeaderRow.FindControl("fltrPROVIDERID2");
                if (ctrl2 != null)
                {
                    DropDownList DDProviderId2 = (DropDownList)ctrl2;
                    selectedValue2 = DDProviderId2.SelectedValue;
                }
            }

            lblTable.Text = "Contract";
            DataView dv = new DataView(Database.Database.ExecuteQuery("Select * from Contract order by AreaManagerId, Priority"));
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
                    //                  [ID], [AREAMANAGERID], [PROVIDERID], [PROVIDERID2], [PRIORITY], [SENDLINKREQUEST], [RELAYINDICATOR], [STARTDATE], [ENDDATE]
                    dv.Table.Rows.Add(new object[] { null, null, null, null, 0, "None", false, DateTime.MinValue, DateTime.MinValue });
                   
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

                Control ctrl2 = grd.HeaderRow.FindControl("fltrPROVIDERID2");
                if (ctrl2 != null)
                {
                    DropDownList DDProviderId2 = (DropDownList)ctrl2;

                    DDProviderId2.DataSource = GetProviders();
                    if (!string.IsNullOrEmpty(selectedValue2))
                        DDProviderId2.SelectedValue = selectedValue2;
                    DDProviderId2.DataBind();
                }
            }

            if (grd.FooterRow != null)
            {
                Control ctrl = grd.FooterRow.FindControl("contractAREAMANAGERID");
                if (ctrl != null)
                {
                    DropDownList DDAreaManager = (DropDownList)ctrl;
                    DDAreaManager.DataSource = Database.Database.ShowTable("AreaManager");
                    DDAreaManager.DataBind();
                }
                ctrl = grd.FooterRow.FindControl("contractPROVIDERID2");
                if (ctrl != null)
                {
                    DropDownList DDProvider2 = (DropDownList)ctrl;
                    DDProvider2.DataSource = Database.Database.ShowTable("Provider");
                    DDProvider2.DataBind();
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
            string filter = "1=1";
            if (grd.HeaderRow != null)
            {
                Control ctrl1 = grd.HeaderRow.FindControl("fltrAREAMANAGERID");
                if (ctrl1 != null)
                {
                    DropDownList fltrAREAMANAGERID = (DropDownList)ctrl1;
                    if (fltrAREAMANAGERID.SelectedValue != "-")
                    {
                        filter = "AND AREAMANAGERID = '" + fltrAREAMANAGERID.SelectedValue + "'";
                    }
                }

                Control ctrl2 = grd.HeaderRow.FindControl("fltrPROVIDERID2");
                if (ctrl2 != null)
                {
                    DropDownList fltrPROVIDERID2 = (DropDownList)ctrl2;
                    if (fltrPROVIDERID2.SelectedValue != "-")
                    {
                        filter = "AND PROVIDERID2 = '" + fltrPROVIDERID2.SelectedValue + "'";
                    }
                }
            }
            LoadData(filter);
        }

        protected void grd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Dictionary<string, object> dic = ValuesFromRow(grd.Rows[grd.EditIndex]);

            SqlCommand com = new SqlCommand("update CONTRACT set AREAMANAGERID=@AREAMANAGERID, PROVIDERID2=@PROVIDERID2, PRIORITY=@PRIORITY, SENDLINKREQUEST=@SENDLINKREQUEST, RELAYINDICATOR=@RELAYINDICATOR, STARTDATE=@STARTDATE, ENDDATE=@ENDDATE where ID=@ID");
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
                    else if (c.GetType().BaseType == typeof(Denion.WebService.Beheer.Controls.TimePicker))
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
            if (dic.ContainsKey("PROVIDERID2"))
                com.Parameters.Add("@PROVIDERID2", System.Data.SqlDbType.Int).Value = dic["PROVIDERID2"];
            if (dic.ContainsKey("PRIORITY"))
                com.Parameters.Add("@PRIORITY", System.Data.SqlDbType.Int).Value = dic["PRIORITY"];
            if (dic.ContainsKey("SENDLINKREQUEST"))
                com.Parameters.Add("@SENDLINKREQUEST", System.Data.SqlDbType.NVarChar, 10).Value = dic["SENDLINKREQUEST"];
            if (dic.ContainsKey("RELAYINDICATOR"))
                com.Parameters.Add("@RELAYINDICATOR", System.Data.SqlDbType.Bit).Value = dic["RELAYINDICATOR"];
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

                SqlCommand com = new SqlCommand("insert into CONTRACT (AREAMANAGERID, PROVIDERID2, PRIORITY, SENDLINKREQUEST, RELAYINDICATOR, STARTDATE, ENDDATE) values (@AREAMANAGERID, @PROVIDERID2, @PRIORITY, @SENDLINKREQUEST, @RELAYINDICATOR, @STARTDATE, @ENDDATE)");
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
                    DropDownList DDAreaManager = (DropDownList)e.Row.FindControl("contractAREAMANAGERID");
                    DDAreaManager.DataSource = Database.Database.ShowTable("AreaManager");
                    DDAreaManager.SelectedValue = ((DataRowView)e.Row.DataItem).Row["AREAMANAGERID"].ToString();
                    DDAreaManager.DataBind();

                    DropDownList DDProvider2 = (DropDownList)e.Row.FindControl("contractPROVIDERID2");
                    DDProvider2.DataSource = Database.Database.ShowTable("Provider");
                    DDProvider2.SelectedValue = ((DataRowView)e.Row.DataItem).Row["PROVIDERID2"].ToString();
                    DDProvider2.DataBind();
                }
            }
        }

        protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand com = new SqlCommand("delete from [Contract] where [ID]=@ID");

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

        protected void fltrPROVIDERID2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList fltrPROVIDERID2 = sender as DropDownList;
            string filter = String.Empty;
            if (fltrPROVIDERID2.SelectedValue != "-")
            {
                filter = "PROVIDERID2 = '" + fltrPROVIDERID2.SelectedValue + "'";
            }
            LoadData(filter);
        }
    }
}