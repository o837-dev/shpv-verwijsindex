using Denion.WebService.Database;
using System;

namespace Denion.WebService.Beheer
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblInfo.Text = DatabaseQueue.Length.ToString();
            }
        }

        protected void btnFork_Click(object sender, EventArgs e)
        {

            Database.Database.Log("Forked from dashboard");
        }
    }
}