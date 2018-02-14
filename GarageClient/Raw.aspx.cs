using System;
using System.Configuration;

namespace GarageClient
{
    public partial class Raw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbAddress.Text = ConfigurationManager.AppSettings["VerwijsIndexURL"];
            }
        }

        private void appendLog(string p)
        {
            tbDebug.Text += "\n[" + DateTime.Now.ToShortTimeString() + "] " + p;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            RawRequest req = new RawRequest(tbRequest.Text);
            Utilities.SendAndReceive(tbAddress.Text, true, ref req);

            if (!string.IsNullOrEmpty(req.Error))
            {
                appendLog("Error: " + req.Error);
            }
            tbResponse.Text = req.Result;
            appendLog("Duration: " + req.Duration.TotalSeconds + " secs");
        }
    }
}
