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
    public partial class ContractUniqueness : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    LoadData(String.Empty);
            //}
        }

        //public DataTable GetAreaManagers()
        //{
        //    DataTable dt = Database.Database.ExecuteQuery("Select distinct cu.AREAMANAGERID as ID, am.DESCRIPTION from ContractUniqueness as cu join AreaManager as am on cu.AREAMANAGERID = am.ID");
        //    DataRow dr = dt.NewRow();
        //    dr["ID"] = "-";
        //    dr["DESCRIPTION"] = "-";
        //    dt.Rows.InsertAt(dr, 0);
        //    return dt;
        //}

        //private void LoadData(string filter)
        //{
        //    string selectedValue = null;
        //    if (grd.HeaderRow != null)
        //    {
        //        Control ctrl = grd.HeaderRow.FindControl("fltrAREAMANAGERID");
        //        if (ctrl != null)
        //        {
        //            DropDownList DDAreaManager = (DropDownList)ctrl;
        //            selectedValue = DDAreaManager.SelectedValue;
        //        }
        //    }

        //    lblTable.Text = "ContractUniqueness";
        //    DataView dv = new DataView(Database.Database.ExecuteQuery("Select * from ContractUniqueness order by AreaManagerId, Priority"));
        //    if (!string.IsNullOrEmpty(filter))
        //        dv.RowFilter = filter;

        //    if (dv.Count == 0)
        //    {
        //        dv.RowFilter = null;
        //        if (!String.IsNullOrEmpty(filter))
        //            lblErr.Text = "Geen resultaat bij zoekcriteria";
        //        else
        //            //dv.AddNew();
        //        if (dv.Count == 0)
        //        {
        //            dv.Table.Rows.Add(new object[] { null, "363", -1, false });
        //        }
        //    }

        //    grd.DataSource = dv;
        //    grd.DataBind();

        //    if (grd.HeaderRow != null)
        //    {
        //        Control ctrl = grd.HeaderRow.FindControl("fltrAREAMANAGERID");
        //        if (ctrl != null)
        //        {
        //            DropDownList DDAreaManager = (DropDownList)ctrl;

        //            DDAreaManager.DataSource = GetAreaManagers();
        //            if (!string.IsNullOrEmpty(selectedValue))
        //                DDAreaManager.SelectedValue = selectedValue;
        //            DDAreaManager.DataBind();                    
        //        }
        //    }

        //    if (grd.FooterRow != null)
        //    {
        //        Control ctrl = grd.FooterRow.FindControl("contractUniquenessAREAMANAGERID");
        //        if (ctrl != null)
        //        {
        //            DropDownList DDAreaManager = (DropDownList)ctrl;
        //            DDAreaManager.DataSource = Database.Database.ShowTable("AreaManager");
        //            DDAreaManager.DataBind();
        //        }
        //    }
        //}

        //private void RefreshPage()
        //{
        //    // prevents the message on page refresh
        //    Response.Redirect(Request.RawUrl);
        //}

        protected void grd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //grd.EditIndex = e.NewEditIndex;
            //string filter = String.Empty;

            //if (grd.HeaderRow != null)
            //{
            //    Control ctrl = grd.HeaderRow.FindControl("fltrAREAMANAGERID");
            //    if (ctrl != null)
            //    {
            //        DropDownList fltrAREAMANAGERID = (DropDownList)ctrl;
            //        if (fltrAREAMANAGERID.SelectedValue != "-")
            //        {
            //            filter = "AREAMANAGERID = '" + fltrAREAMANAGERID.SelectedValue + "'";
            //        }
            //    }
            //}
            //LoadData(filter);
        }

        protected void grd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Dictionary<string, object> dic = ValuesFromRow(grd.Rows[grd.EditIndex]);

            //SqlCommand com = new SqlCommand("update CONTRACTUNIQUENESS set AREAMANAGERID=@AREAMANAGERID, PRIORITY=@PRIORITY, ISUNIQUE=@ISUNIQUE where ID=@ID");
            //ArgumentsFromDictionary(com, dic);
            //if (validateData(dic).valid)
            //{
            //    com.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = grd.DataKeys[grd.EditIndex].Value;
            //    Database.Database.ExecuteScalar(com);

            //    RefreshPage();
            //}
            //else
            //{
            //    lblErr.Text = validateData(dic).results;
            //}
        }

        protected void grd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //RefreshPage();
        }

        //private Dictionary<string, object> ValuesFromRow(GridViewRow row)
        //{
        //    Dictionary<string, object> dic = new Dictionary<string, object>();
        //    for (int i = 0; i < grd.Columns.Count; i++)
        //    {
        //        foreach (Control c in row.Cells[i].Controls)
        //        {
        //            if (c.GetType() == typeof(TextBox))
        //            {
        //                dic.Add(grd.Columns[i].HeaderText, ((TextBox)c).Text);
        //            }
        //            else if (c.GetType() == typeof(DropDownList))
        //            {
        //                dic.Add(grd.Columns[i].HeaderText, ((DropDownList)c).SelectedValue);
        //            }
        //            else if (c.GetType() == typeof(CheckBox))
        //            {
        //                dic.Add(grd.Columns[i].HeaderText, ((CheckBox)c).Checked);
        //            }
        //            else if (c.GetType().BaseType == typeof(Denion.WebService.Beheer.Controls.TimePicker))
        //            {
        //                dic.Add(grd.Columns[i].HeaderText, ((Controls.TimePicker)c).Value);
        //            }
        //        }
        //    }
        //    return dic;
        //}

        //private void ArgumentsFromDictionary(SqlCommand com, Dictionary<string, object> dic)
        //{
        //    if (dic.ContainsKey("AREAMANAGERID"))
        //        com.Parameters.Add("@AREAMANAGERID", System.Data.SqlDbType.NVarChar, 200).Value = dic["AREAMANAGERID"];
        //    if (dic.ContainsKey("PRIORITY"))
        //        com.Parameters.Add("@PRIORITY", System.Data.SqlDbType.Int).Value = dic["PRIORITY"];
        //    if (dic.ContainsKey("ISUNIQUE"))
        //        com.Parameters.Add("@ISUNIQUE", System.Data.SqlDbType.Bit).Value = dic["ISUNIQUE"];
        //}

        //private validationResult validateData(Dictionary<string, object> dic)
        //{
        //    validationResult res = new validationResult();
        //    if (dic.ContainsKey("PRIORITY"))
        //    {

        //        String prio = dic["PRIORITY"].ToString();
        //        int output;
        //        bool valid = int.TryParse(prio, out output);
        //        if (!valid)
        //            res.Records.Add(new validationRecord() { Field = "PRIORITY", Message = "Geen geldige waarde voor het prioriteits veld." });
        //    }
        //    return res;
        //}

        //class validationResult
        //{
        //    public List<validationRecord> Records { get; set; }
        //    public bool valid { get { return Records.Count == 0; } }
        //    public string results
        //    {
        //        get
        //        {
        //            string res = String.Empty;
        //            foreach (validationRecord rec in Records)
        //            {
        //                res += " " + rec.Message;
        //            }
        //            return res;
        //        }

        //    }
        //    public validationResult()
        //    {
        //        Records = new List<validationRecord>();
        //    }

        //}

        //class validationRecord
        //{
        //    public String Field { get; set; }
        //    public String Message { get; set; }
        //}

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Insert")
            //{
            //    Dictionary<string, object> dic = ValuesFromRow(grd.FooterRow);
            //    if (validateData(dic).valid)
            //    {
            //        SqlCommand com = new SqlCommand("insert into CONTRACTUNIQUENESS (AREAMANAGERID, PRIORITY, ISUNIQUE) values (@AREAMANAGERID, @PRIORITY, @ISUNIQUE)");
            //        ArgumentsFromDictionary(com, dic);

            //        Database.Database.ExecuteScalar(com);

            //        RefreshPage();
            //    }
            //    else
            //        lblErr.Text = validateData(dic).results;
            //}
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    object ID = grd.DataKeys[e.Row.RowIndex].Value;
            //    if (ID == DBNull.Value)
            //    {
            //        e.Row.Visible = false;
            //    }
            //    else
            //    {
            //        DropDownList DDAreaManager = (DropDownList)e.Row.FindControl("contractUniquenessAREAMANAGERID");
            //        DDAreaManager.DataSource = Database.Database.ShowTable("AreaManager");
            //        if (((DataRowView)e.Row.DataItem).Row["AREAMANAGERID"] != DBNull.Value)
            //            DDAreaManager.SelectedValue = ((DataRowView)e.Row.DataItem).Row["AREAMANAGERID"].ToString();
            //        DDAreaManager.DataBind();
            //    }
            //}
        }

        protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //SqlCommand com = new SqlCommand("delete from [CONTRACTUNIQUENESS] where [ID]=@ID");

            //com.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = grd.DataKeys[e.RowIndex].Value;
            //Database.Database.ExecuteScalar(com);

            //RefreshPage();
        }

        protected void fltrAREAMANAGERID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DropDownList fltrAREAMANAGERID = sender as DropDownList;
            //string filter = String.Empty;
            //if (fltrAREAMANAGERID.SelectedValue != "-")
            //{
            //    filter = "AREAMANAGERID = '" + fltrAREAMANAGERID.SelectedValue + "'";
            //}
            //LoadData(filter);
        }

        /// <summary>
        /// DropDownList complains about the use of EVAL without BIND
        /// 
        /// this is a workaround to hide the dropdown when then gridview shows a dummy record
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        //protected bool HiddenOnDummy(object val)
        //{
        //    bool rv = false;
        //    if (val is DataRowView)
        //    {
        //        DataRowView drv = (DataRowView)val;
        //        object ID = drv["ID"];
        //        if (ID != null)
        //            rv = ((int)drv["ID"] >= 0);
        //    }
        //    return rv;
        //}
    }
}