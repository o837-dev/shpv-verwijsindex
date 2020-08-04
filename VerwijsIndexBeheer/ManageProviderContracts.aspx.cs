using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Denion.WebService.Database;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using Denion.WebService.VerwijsIndex;

namespace Denion.WebService.Beheer
{
    public partial class ManageProviderContracts : System.Web.UI.Page
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
                    //                               [ID], [AREAMANAGERID], [PROVIDERID], [PROVIDERID2], [PRIORITY], [SENDLINKREQUEST], [RELAYINDICATOR], [STARTDATE], [ENDDATE], [LINKTYPE], [NPRREGISTRATION]
                    dv.Table.Rows.Add(new object[] { null, null, null, null, 0, "None", false, DateTime.MinValue, DateTime.MinValue, "iNclusive", false });

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



        private void RefreshPage() {
            // prevents the message on page refresh
            Response.Redirect(Request.RawUrl, false);
        }

        protected void grd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grd.EditIndex = e.NewEditIndex;

            LoadData(filterText());
        }

        protected void grd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Dictionary<string, object> dic = ValuesFromRow(grd.Rows[grd.EditIndex]);
            dic["ID"] = grd.DataKeys[grd.EditIndex].Value;

            string validationResult = Validate(dic);
            if (!string.IsNullOrEmpty(validationResult))
            {
                lblErr.Text = validationResult;
            }
            else
            {
                SqlCommand com = new SqlCommand("update CONTRACT set AREAMANAGERID=@AREAMANAGERID, PROVIDERID2=@PROVIDERID2, PRIORITY=@PRIORITY, SENDLINKREQUEST=@SENDLINKREQUEST, LINKTYPE=@LINKTYPE, RELAYINDICATOR=@RELAYINDICATOR, NPRREGISTRATION=@NPRREGISTRATION, STARTDATE=@STARTDATE, ENDDATE=@ENDDATE where ID=@ID");
                ArgumentsFromDictionary(com, dic);

                Database.Database.ExecuteScalar(com);

                RefreshPage();
            }
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
            if (dic.ContainsKey("ID"))
                com.Parameters.Add("@ID", System.Data.SqlDbType.NVarChar, 200).Value = dic["ID"];
            if (dic.ContainsKey("AREAMANAGERID"))
                com.Parameters.Add("@AREAMANAGERID", SqlDbType.NVarChar, 200).Value = dic["AREAMANAGERID"];
            if (dic.ContainsKey("PROVIDERID2"))
                com.Parameters.Add("@PROVIDERID2", SqlDbType.Int).Value = dic["PROVIDERID2"];
            if (dic.ContainsKey("PRIORITY"))
                com.Parameters.Add("@PRIORITY", SqlDbType.Int).Value = dic["PRIORITY"];
            if (dic.ContainsKey("SENDLINKREQUEST"))
                com.Parameters.Add("@SENDLINKREQUEST", SqlDbType.NVarChar, 10).Value = dic["SENDLINKREQUEST"];
            if (dic.ContainsKey("LINKTYPE"))
                com.Parameters.Add("@LINKTYPE", SqlDbType.NVarChar, 10).Value = dic["LINKTYPE"];
            if (dic.ContainsKey("RELAYINDICATOR"))
                com.Parameters.Add("@RELAYINDICATOR", SqlDbType.Bit).Value = dic["RELAYINDICATOR"];
            if (dic.ContainsKey("NPRREGISTRATION"))
                com.Parameters.Add("@NPRREGISTRATION", SqlDbType.Bit).Value = dic["NPRREGISTRATION"];
            if (dic.ContainsKey("STARTDATE"))
                com.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = dic["STARTDATE"];
            if (dic.ContainsKey("ENDDATE"))
                com.Parameters.Add("@ENDDATE", SqlDbType.DateTime).Value = dic["ENDDATE"];
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Dictionary<string, object> dic = ValuesFromRow(grd.FooterRow);
                string validationResult = Validate(dic);
                if (!string.IsNullOrEmpty(validationResult))
                {
                    lblErr.Text = validationResult;
                }
                else
                {
                    SqlCommand com = new SqlCommand("insert into CONTRACT (AREAMANAGERID, PROVIDERID2, PRIORITY, SENDLINKREQUEST, LINKTYPE, RELAYINDICATOR, NPRREGISTRATION, STARTDATE, ENDDATE) values (@AREAMANAGERID, @PROVIDERID2, @PRIORITY, @SENDLINKREQUEST, @LINKTYPE, @RELAYINDICATOR, @NPRREGISTRATION, @STARTDATE, @ENDDATE)");
                    ArgumentsFromDictionary(com, dic);

                    Database.Database.ExecuteScalar(com);

                    RefreshPage();
                }
            }
        }


        //public static T DataRowToObject<T>(DataRow r)
        //{
        //    T t = (T)Activator.CreateInstance(typeof(T));
        //    foreach (DataColumn dc in r.Table.Columns)
        //    {
        //        if (r[dc] != DBNull.Value)
        //        {
        //            try
        //            {
        //                PropertyInfo prop = t.GetType().GetProperty(dc.ColumnName);
        //                if (prop !=null)
        //                    prop.SetValue(t, r[dc], null);
        //            }
        //            catch (Exception)
        //            {
        //                throw new Exception("Failed to convert: " + dc.ColumnName + "[" + dc.DataType.ToString() + "]");
        //            }
        //        }
        //    }
        //    return t;
        //}

        public static T DictionaryToObject<T>(Dictionary<string, object> dic)
        {
            T t = (T)Activator.CreateInstance(typeof(T));
            foreach (string key in dic.Keys)
            {
                if (dic[key] != null)
                {
                    PropertyInfo prop = null;
                    try
                    {
                        prop = t.GetType().GetProperty(key);
                        object value = dic[key];
                        if (value.GetType() != prop.PropertyType)
                        {
                            //Debug.WriteLine("Convert: " + key + " from [" + dic[key].GetType().ToString() + "] to [" + prop.PropertyType.ToString() + "]");
                            value = Convert.ChangeType(value, prop.PropertyType);
                        }

                        prop.SetValue(t, value, null);

                    }
                    catch (Exception)
                    {
                        if (prop != null)
                            throw new Exception("Failed to convert: " + key + " from [" + dic[key].GetType().ToString() + "] to [" + prop.PropertyType.ToString() + "]");
                        else
                            throw new Exception("Failed to convert: " + key + "[" + dic[key].GetType().ToString() + "]");
                    }
                }
            }
            return t;
        }
        
        private string Validate(Dictionary<string, object> dic)
        {
            return null; 
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
            LoadData(filterText());
        }

        protected void fltrPROVIDERID2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(filterText());
        }

        protected string filterText()
        {
            string filter = "1=1";
            if (grd.HeaderRow != null)
            {
                Control ctrl1 = grd.HeaderRow.FindControl("fltrAREAMANAGERID");
                if (ctrl1 != null)
                {
                    DropDownList fltrAREAMANAGERID = (DropDownList)ctrl1;
                    if (fltrAREAMANAGERID.SelectedValue != "-")
                    {
                        filter += "AND AREAMANAGERID = '" + fltrAREAMANAGERID.SelectedValue + "'";
                    }
                }

                Control ctrl2 = grd.HeaderRow.FindControl("fltrPROVIDERID2");
                if (ctrl2 != null)
                {
                    DropDownList fltrPROVIDERID2 = (DropDownList)ctrl2;
                    if (fltrPROVIDERID2.SelectedValue != "-")
                    {
                        filter += "AND PROVIDERID2 = '" + fltrPROVIDERID2.SelectedValue + "'";
                    }
                }
            }
            return filter;
        }
    }
}