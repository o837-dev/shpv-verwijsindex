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
    public partial class Consumers : System.Web.UI.Page
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
            lblTable.Text = "Consumer";
            DataTable dt = Database.Database.ShowTable("Consumer");
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

            SqlCommand com = new SqlCommand("update CONSUMER set ID=@ID, DESCRIPTION=@DESCRIPTION, URL=@URL where CID=@CID");
            ArgumentsFromDictionary(com, dic);

            com.Parameters.Add("@CID", System.Data.SqlDbType.Int).Value = grd.DataKeys[grd.EditIndex].Value;
            Database.Database.ExecuteScalar(com);

            RefreshPage();
        }

        protected void grd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            RefreshPage();
        }

        protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand com = new SqlCommand("delete from [CONSUMER] where [CID]=@CID");
            com.Parameters.Add("@CID", System.Data.SqlDbType.Int).Value = grd.DataKeys[e.RowIndex].Value;
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
            if (dic.ContainsKey("ID"))
                com.Parameters.Add("@ID", System.Data.SqlDbType.NVarChar, 200).Value = dic["ID"];
            if (dic.ContainsKey("DESCRIPTION"))
                com.Parameters.Add("@DESCRIPTION", System.Data.SqlDbType.NVarChar, 200).Value = dic["DESCRIPTION"];
            if (dic.ContainsKey("URL"))
                com.Parameters.Add("@URL", System.Data.SqlDbType.NVarChar, 200).Value = dic["URL"];
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Dictionary<string, string> dic = ValuesFromRow(grd.FooterRow);
                SqlCommand com = new SqlCommand("INSERT INTO CONSUMER (ID, DESCRIPTION, URL) values (@ID, @DESCRIPTION, @URL)");
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

                    SqlCommand com = new SqlCommand("Select Count(*) From [ConsumerContract] where [CONSUMERID]=@CID");
                    com.Parameters.Add("@CID", System.Data.SqlDbType.NVarChar, 200).Value = ((DataRowView)e.Row.DataItem).Row["CID"];

                    int refCount = (int)Database.Database.ExecuteScalar(com);
                    if (refCount > 0)
                    {
                        btn.ToolTip = "Er zijn nog " + refCount + " verwijzingen naar deze CONSUMER in de ConsumerContract tabel, verwijderen is niet mogelijk.";
                        btn.OnClientClick = "alert('Verwijderen is niet mogelijk, er zijn nog " + refCount + " verwijzingen naar deze Consumer in de Contract tabel.');  return false; ";
                    }
                }
            }
        }
    }
}