using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Denion.Web.ProviderClient
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Updates: " + ((TimerStatusUpdate.Enabled) ? "Enabled" : "Disabled");
            
            if (!IsPostBack)
            {
                List<string> l = new List<string>();
                l.Add("a");
                l.Add("b");
                l.Add("c");
                GridView1.DataSource = l;
                GridView1.DataBind();
            }
        }

        protected void TimerStatusUpdate_Tick(object sender, EventArgs e)
        {
            List<string> l = new List<string>();
            l.Add("a");
            l.Add("b");
            l.Add("c");
            l.Add("d");
            l.Add("e");
            GridView1.DataSource = l;
            GridView1.DataBind();        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TimerStatusUpdate.Enabled = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TimerStatusUpdate.Enabled = false;
        }
    }
}
