using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Denion.WebService.Beheer
{
    public partial class Link : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (!IsPostBack)
            {
                LoadData(string.Empty, true);
            }
        }
        protected void btnfilter_Click(object sender, EventArgs e)
        {
            LoadData(txtWhere.Text, false);
        }
        protected void btnReCount_Click(object sender, EventArgs e)
        {
            LoadData(txtWhere.Text, true);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            LoadData(string.Empty, false);
        }

        protected void btnFetch_Click(object sender, EventArgs e)
        {
            LoadData(string.Empty, false);
        }

        private void LoadData(string filter, bool descOnly)
        {
            string table = "Link";
            lblTable.Text = table;
            try
            {
                DataView dv = null;
                if (descOnly)
                {
                    dv = new DataView(Database.Database.DescTable(table));
                    dv.AddNew();
                }
                else
                {
                    string SQL = "Select top 1000 * FROM " + table + ((!string.IsNullOrEmpty(filter)) ? " WHERE " + filter : string.Empty);
                    dv = new DataView(Database.Database.ExecuteQuery(SQL));
                }
                GridView1.DataSource = dv;
                GridView1.DataBind();

                if (descOnly)
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        string SQL = "Select count(*) FROM " + table + " WHERE " + filter;
                        object count = Database.Database.ExecuteScalar(SQL);
                        lblErr.Text = "With this filter, the first 1000 of " + count + " records will be fetched";
                    }
                    else
                    {
                        lblErr.Text = "Without any filter, the first 1000 of " + Database.Database.CountRecords(table) + " records will be fetched";
                    }
                }
                else
                {
                    lblErr.Text = dv.Count + " records";
                }
            }
            catch (Exception ex)
            {
                lblErr.Text = ex.Message + "<br / >" + ex.StackTrace;
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                if (e.Row.Cells.Count == dr.Row.ItemArray.Length)
                {
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        if (dr.Row.ItemArray[i].GetType() == typeof(bool))
                        {
                            e.Row.Cells[i].Text = dr.Row.ItemArray[i].ToString();
                        }
                    }
                }
            }
        }
    }
}