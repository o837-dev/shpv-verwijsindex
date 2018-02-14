using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
using System.Threading;
using System.Xml;
using Denion.WebService.Database;

namespace Denion.Web.ProviderClient
{
    public partial class Batch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = null;
            if (FileUploadControl.HasFile)
            {
                DataTable dt = null;
                try
                {
                    string fileName = FileUploadControl.FileName;
                    string content = null;

                    using (System.IO.StreamReader sr = new System.IO.StreamReader(FileUploadControl.FileContent))
                    {
                        content = sr.ReadToEnd();
                    }
                    dt = ToDataTable(fileName, content);
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }

                if (dt != null)
                {
                    try
                    {
                        Work(dt);

                        string newfile = "new_" + dt.TableName + ".csv";
                        string data = ToCSV(dt, ";");
                        ReturnCsvFile(data, this.Response, newfile);
                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Text = "Error: " + ex.Message;
                    }
                }
            }
        }

        protected DataTable ToDataTable(string filename, string content)
        {
            DataTable dt = new DataTable();
            using (System.IO.StringReader sr = new StringReader(content))
            {
                LumenWorks.Framework.IO.Csv.CsvReader csv = new LumenWorks.Framework.IO.Csv.CsvReader(sr, true, ';');
                dt.TableName = filename.Substring(0, filename.LastIndexOf('.'));

                foreach (string head in csv.GetFieldHeaders())
                {
                    DataColumn dc = dt.Columns.Add();
                    dc.ColumnName = head;
                }

                string[] arr = new string[csv.FieldCount];
                while (csv.ReadNextRecord())
                {
                    csv.CopyCurrentRecordTo(arr);
                    DataRow dr = dt.Rows.Add(arr);
                }
            }
            return dt;
        }

        protected string ToCSV(DataTable dt, string separator)
        {
            StringBuilder sb = new StringBuilder();

            //headers
            List<string> row = new List<string>();
            foreach (DataColumn dc in dt.Columns)
            {
                row.Add(dc.ColumnName);
            }
            sb.Append(string.Join(separator, row.ToArray()) + "\r\n");

            //data
            foreach (DataRow dr in dt.Rows)
            {
                row.Clear();
                foreach (object obj in dr.ItemArray)
                {
                    row.Add(obj.ToString());
                }
                sb.Append(string.Join(separator, row.ToArray()) + "\r\n");
            }

            return sb.ToString();
        }

        protected void ReturnCsvFile(string data, HttpResponse res, string filename)
        {
            res.Clear();
            res.BufferOutput = false;

            res.AddHeader("Cache-Control", "must-revalidate");
            res.AddHeader("Pragma", "must-revalidate");

            res.ContentType = "text/csv";

            res.AddHeader("Content-disposition", "inline; filename=\"" + filename + "\"");

            res.Write(data);
            res.End();
        }

        internal void EnsureColumn(ref DataTable dt, string columnName)
        {
            if (!dt.Columns.Contains(columnName))
                dt.Columns.Add(columnName);

        }

        protected void Work(DataTable dt)
        {
            //prepare
            EnsureColumn(ref dt, "Remark");
            EnsureColumn(ref dt, "RemarkId");
            EnsureColumn(ref dt, "Error");


            //work
            StringBuilder messages = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                String singleMsg = Properties.Settings.Default.LinkRegistrationRequestMessage;

                singleMsg = singleMsg.Replace("<!--ProviderId-->", dr["ProviderId"].ToString());
                singleMsg = singleMsg.Replace("<!--LinkId-->", dr["LinkId"].ToString());
                singleMsg = singleMsg.Replace("<!--VehicleId-->", dr["VehicleId"].ToString());
                singleMsg = singleMsg.Replace("<!--CountryCode-->", dr["CountryCode"].ToString());
                singleMsg = singleMsg.Replace("<!--ValidFrom-->", dr["ValidFrom"].ToString());
                singleMsg = singleMsg.Replace("<!--ValidUntil-->", dr["ValidUntil"].ToString());
                messages.Append(singleMsg);
            }

            RawRequest req = new RawRequest(Properties.Settings.Default.LinkRegistrationRequestContainer);
            req.Message = req.Message.Replace("<!--MessageID-->", Guid.NewGuid().ToString());
            req.Message = req.Message.Replace("<!--To-->", Properties.Settings.Default.ProviderServiceURL);
            req.Message = req.Message.Replace("<!--LinkRegistrationRequest-->", messages.ToString());

            Utilities.SendAndReceive(Properties.Settings.Default.ProviderServiceURL, true, ref req);

            if (!string.IsNullOrEmpty(req.Error))
            {

                Database.Log("BATCH; Error in: " + req.Message);
                Database.Log("BATCH; Details: " + req.Error);
            }
            if (req.Result != null)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(req.Result);

                foreach (DataRow dr in dt.Rows)
                {
                    dr["Error"] = req.Error;

                    dr["Remark"] = getInnerTextFromXml(xdoc, "Remark");
                    dr["RemarkId"] = getInnerTextFromXml(xdoc, "RemarkId");
                }
            }
        }

        public string getInnerTextFromXml(XmlDocument doc, string node)
        {
            XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
            mgr.AddNamespace("b", "https://verwijsindex.shpv.nl/messages/");

            XmlNode xn = doc.SelectSingleNode("//b:" + node, mgr);
            return (xn != null) ? xn.InnerText : null;
        }

        public string getValueFromXml(XmlDocument doc, string node)
        {
            XmlNode xn = doc.SelectSingleNode("//*[local-name() = '" + node + "']");
            return (xn != null) ? xn.Value : null;
        }
    }
}
