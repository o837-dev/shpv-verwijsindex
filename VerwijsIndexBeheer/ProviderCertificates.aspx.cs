using Denion.WebService.Cryptography;
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
    public partial class ProviderCertificates : System.Web.UI.Page
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
            lblTable.Text = "ProviderNPRCertificate";
            DataTable dt = Database.Database.ShowTable("ProviderNPRCertificate");
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
            // prevents the message on page refresh
            Response.Redirect(Request.RawUrl);
        }

        protected void grd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grd.EditIndex = e.NewEditIndex;
            LoadData();

            GridViewRow row = grd.Rows[grd.EditIndex];
            TextBox tbCertPin = (TextBox)row.FindControl("ProviderCERTPIN");
            if (tbCertPin != null) tbCertPin.Attributes["Value"] = "********";
        }
        protected void grd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grd.Rows[grd.EditIndex];
            Dictionary<string, object> dic = ValuesFromRow(row);

            string sql = "update ProviderNPRCertificate set PROVIDER=@PROVIDER, VALIDFROM=@VALIDFROM, VALIDUNTIL=@VALIDUNTIL, NPRREGISTRATION=@NPRREGISTRATION where ID=@ID";
            TextBox tbCertPin = (TextBox)row.FindControl("ProviderCERTPIN");
            if (tbCertPin != null && !string.IsNullOrEmpty(tbCertPin.Text) && tbCertPin.Text != "********")
            {
                sql = "update ProviderNPRCertificate set PROVIDER=@PROVIDER, CERTPIN=@CERTPIN, VALIDFROM=@VALIDFROM, VALIDUNTIL=@VALIDUNTIL, NPRREGISTRATION=@NPRREGISTRATION where ID=@ID";
            }
            SqlCommand com = new SqlCommand(sql);
            ArgumentsFromDictionary(com, dic);

            com.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = grd.DataKeys[grd.EditIndex].Value;

            string query = com.CommandText;
            foreach (SqlParameter p in com.Parameters) {
                query = query.Replace(p.ParameterName, p.Value.ToString());
            }
            Database.Database.Log(query);


            Database.Database.ExecuteScalar(com);

            RefreshPage();
        }

        protected void grd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            RefreshPage();
        }

        protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand com = new SqlCommand("delete from [ProviderNPRCertificate] where [ID]=@ID");
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
                        dic.Add(grd.Columns[i].HeaderText, ((TextBox)c).Text);
                    }
                    else if (c.GetType().BaseType == typeof(Denion.WebService.Beheer.Controls.TimePicker))
                    {
                        dic.Add(grd.Columns[i].HeaderText, ((Controls.TimePicker)c).Value);
                    } 
                    else if (c.GetType() == typeof(CheckBox)) {
                        dic.Add(grd.Columns[i].HeaderText, ((CheckBox)c).Checked);
                    } 
                    else if (c.GetType() == typeof(FileUpload))
                    {
                        dic.Add("FILENAME", ((FileUpload)c).FileName);
                        dic.Add(grd.Columns[i].HeaderText, ((FileUpload)c).FileBytes);
                    }
                }
            }
            return dic;
        }

        private void ArgumentsFromDictionary(SqlCommand com, Dictionary<string, object> dic)
        {
            if (dic.ContainsKey("PROVIDER"))
                com.Parameters.Add("@PROVIDER", SqlDbType.NVarChar, 200).Value = dic["PROVIDER"];
            if (dic.ContainsKey("CERTIFICATE"))
                com.Parameters.Add("@CERTIFICATE", SqlDbType.Image).Value = dic["CERTIFICATE"];
            if (dic.ContainsKey("FILENAME"))
                com.Parameters.Add("@FILENAME", SqlDbType.NVarChar, 255).Value = dic["FILENAME"];
            if (dic.ContainsKey("CERTPIN"))
                com.Parameters.Add("@CERTPIN", SqlDbType.NVarChar, 50).Value =  Rijndael.Encrypt(dic["CERTPIN"] as string);
            if (dic.ContainsKey("VALIDFROM"))
                com.Parameters.Add("@VALIDFROM", SqlDbType.DateTime).Value = dic["VALIDFROM"];
            if (dic.ContainsKey("VALIDUNTIL"))
                com.Parameters.Add("@VALIDUNTIL", SqlDbType.DateTime).Value = dic["VALIDUNTIL"];
            if (dic.ContainsKey("NPRREGISTRATION"))
                com.Parameters.Add("@NPRREGISTRATION", SqlDbType.Bit).Value = dic["NPRREGISTRATION"];
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Dictionary<string, object> dic = ValuesFromRow(grd.FooterRow);
                SqlCommand com = new SqlCommand("INSERT INTO ProviderNPRCertificate (PROVIDER, FILENAME, CERTIFICATE, CERTPIN, VALIDFROM, VALIDUNTIL, NPRREGISTRATION) values (@PROVIDER, @FILENAME,  @CERTIFICATE, @CERTPIN, @VALIDFROM, @VALIDUNTIL, @NPRREGISTRATION)");
                ArgumentsFromDictionary(com, dic);

                Database.Database.ExecuteScalar(com);

                RefreshPage();
            }
        }     
    }
}