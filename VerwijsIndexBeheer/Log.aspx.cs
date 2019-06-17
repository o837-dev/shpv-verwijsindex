﻿using Denion.WebService.Database;
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
    public partial class Log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (!IsPostBack)
            {
                LoadData(string.Empty, false);
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
            string table = "Log";
            if (!string.IsNullOrEmpty(table))
            {
                lblTable.Text = table;
                try
                {
                    DataView dv = null;
                    if (descOnly)
                    {
                        dv = new DataView(Database.Database.DescTable(table, Database.Database.LoggingServerConnectionString()));
                        dv.AddNew();
                    }
                    else
                    {
                        string SQL = "Select top 1000 * FROM " + table + ((!string.IsNullOrEmpty(filter)) ? " WHERE " + filter : string.Empty) + " ORDER BY RECEIVED DESC ";
                        dv = new DataView(Database.Database.ExecuteQuery(SQL, Database.Database.LoggingServerConnectionString()));

                        /*
                        DataTable dt = Denion.WebService.Database.Database.ShowTable(table);
                        dv = new DataView(dt);
                        if (!string.IsNullOrEmpty(filter))
                        {
                            dv.RowFilter = filter;
                        }*/
                    }
                    grd.DataSource = dv;
                    grd.DataBind();

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
                            lblErr.Text = "Without any filter, the last 1000 of " + Database.Database.CountRecords(table) + " records will be fetched";
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
        }
    }
}