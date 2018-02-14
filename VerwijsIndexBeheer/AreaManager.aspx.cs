using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Denion.WebService.Database;
using System.Data;

namespace Denion.WebService.Beheer
{
    public partial class AreaManager : System.Web.UI.Page
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
            lblTable.Text = "AreaManager";
            DataTable dt = Database.Database.ShowTable("AreaManager");
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

            SqlCommand com = new SqlCommand("update AREAMANAGER set ID=@ID, DESCRIPTION=@DESCRIPTION where ID=@OLDID");
            ArgumentsFromDictionary(com, dic);

            com.Parameters.Add("@OLDID", System.Data.SqlDbType.NVarChar, 200).Value = grd.DataKeys[grd.EditIndex].Value;
            Database.Database.ExecuteScalar(com);

            RefreshPage();
        }

        protected void grd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            RefreshPage();
        }

        protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand com = new SqlCommand("delete from [AREAMANAGER] where [ID]=@ID");
            com.Parameters.Add("@ID", System.Data.SqlDbType.NVarChar, 200).Value = grd.DataKeys[e.RowIndex].Value;
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
                        dic.Add(grd.Columns[i].HeaderText, ((TextBox)c).Text);
                    }
                }
            }
            return dic;
        }

        private void ArgumentsFromDictionary(SqlCommand com, Dictionary<string, string> dic)
        {
            foreach (string key in dic.Keys)
                com.Parameters.Add("@" + key, System.Data.SqlDbType.NVarChar, 200).Value = dic[key];
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Dictionary<string, string> dic = ValuesFromRow(grd.FooterRow);
                SqlCommand com = new SqlCommand("INSERT INTO AREAMANAGER (ID, DESCRIPTION) values (@ID, @DESCRIPTION)");
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

                Control ctrl = e.Row.FindControl("btnDelete");
                if (ctrl != null)
                {
                    LinkButton btn = (LinkButton)ctrl;

                    SqlCommand com = new SqlCommand(
                        "Select 'ConsumerContract' as [Table], Count(*) as [RefCount] From [ConsumerContract] where [AREAMANAGERID]=@AREAMANAGERID having COUNT(*) > 0 " +
                        " union " +
                        " Select 'Contract', Count(*) From[Contract] where[AREAMANAGERID] = @AREAMANAGERID having COUNT(*) > 0 ");
                    com.Parameters.Add("@AREAMANAGERID", System.Data.SqlDbType.NVarChar, 200).Value = ((DataRowView)e.Row.DataItem).Row["ID"];
                    DataTable dt = Database.Database.ExecuteQuery(com);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int refCount = 0;
                        string refDesc = String.Empty;
                        for(int i = 0; i< dt.Rows.Count; i++)
                        {
                            DataRow dr = dt.Rows[i];

                            refCount += (int)dr["RefCount"];
                            if (i > 0) refDesc += " en ";
                            refDesc += dr["RefCount"] + " in " + dr["Table"];
                        }
                        btn.ToolTip = "Er zijn nog " + refCount + " verwijzingen naar deze AreaManager, " + refDesc + ", verwijderen is niet mogelijk.";
                        btn.OnClientClick = "alert('"+ btn.ToolTip + "');  return false; ";
                    }
                }
            }
        }
    }
}