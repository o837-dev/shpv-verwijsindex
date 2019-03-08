using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Denion.WebService.VerwijsIndex;
using ManualProviderService.Properties;
using System.Configuration;
using System.Xml;

namespace ManualProviderService
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblProviderId.Text = ConfigurationManager.AppSettings["ProviderId"];
                txtValidFrom.Text = DateTime.Now.ToShortDateString();
                txtValidUntil.Text = DateTime.Now.AddMonths(2).ToShortDateString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Update();
        }

        protected void TimerStatusUpdate_Tick(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            txtPaymentAuthorisationId.Text = DateTime.Now.ToFileTime().ToString();
            int iReqs = 0;
            if (Application["reqlist"] != null)
            {
                Dictionary<UniqueId, PaymentStartRequest> reqs = (Dictionary<UniqueId, PaymentStartRequest>)Application["reqlist"];
                iReqs += reqs.Count;

                var res = from r in reqs select new MyPaymentStartRequest(r.Key, r.Value);
                GridView1.DataSource = res;
                GridView1.DataBind();
            }

            //if (Application["llreqlist"] != null)
            //{
            //    Dictionary<UniqueId, LinkRequest> llreqs = (Dictionary<UniqueId, LinkRequest>)Application["llreqlist"];
            //    iReqs += llreqs.Count;

            //    var llres = from r in llreqs select new MyLinkRequest(r.Key, r.Value);
            //    GridView2.DataSource = llres;
            //    GridView2.DataBind();
            //}

            if (iReqs > 0)
                Title = "(" + iReqs + ") " + "ProviderService";
            else
                Title = "ProviderService";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Grant")
            {
                UniqueId uid = new UniqueId(e.CommandArgument.ToString());
                Dictionary<UniqueId, PaymentStartRequest> reqlist = (Dictionary<UniqueId, PaymentStartRequest>)Application["reqlist"];
                Dictionary<UniqueId, PaymentStartResponse> reslist = (Dictionary<UniqueId, PaymentStartResponse>)Application["reslist"];

                PaymentStartRequest req = reqlist[uid];
                PaymentStartResponse res = new PaymentStartResponse();

                res.PaymentAuthorisationId = long.Parse(txtPaymentAuthorisationId.Text);
                res.ProviderId = lblProviderId.Text;
                res.Remark = "none";
                res.RemarkId = "0";

                reslist.Add(uid, res);
            }
        }

        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Grant")
        //    {
        //        UniqueId uid = new UniqueId(e.CommandArgument.ToString());
        //        Dictionary<UniqueId, LinkRequest> llreqlist = (Dictionary<UniqueId, LinkRequest>)Application["llreqlist"];
        //        Dictionary<UniqueId, LinkResponse> llreslist = (Dictionary<UniqueId, LinkResponse>)Application["llreslist"];

        //        LinkRequest req = llreqlist[uid];
        //        LinkResponse res = new LinkResponse();

        //        int row = int.Parse(e.CommandArgument.ToString());

        //        res.LinkId = txtPaymentAuthorisationId.Text;
        //        res.ProviderId = lblProviderId.Text;
        //        res.ValidFrom = DateTime.Parse(txtValidFrom.Text);
        //        res.ValidUntil = DateTime.Parse(txtValidUntil.Text);

        //        llreslist.Add(uid, res);
        //    }
        //}

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            TimerStatusUpdate.Enabled = !TimerStatusUpdate.Enabled;
            btnRefresh.Text = (TimerStatusUpdate.Enabled) ? "Stop refresh" : "Auto refresh";
        }
    }

    public class MyPaymentStartRequest : PaymentStartRequest
    {
        public MyPaymentStartRequest(UniqueId uuid, PaymentStartRequest req)
        {
            this.AccessId = req.AccessId;
            this.Amount = req.Amount;
            this.AreaId = req.AreaId;
            this.AreaManagerId = req.AreaManagerId;
            this.CountryCode = req.CountryCode;
            this.UUID = uuid;
            this.EndDateTime = req.EndDateTime;
            this.StartDateTime= req.StartDateTime;
            this.Token = req.Token;
            this.TokenType = req.TokenType;
            this.VAT = req.VAT;
            this.VehicleId = req.VehicleId;
            this.VehicleIdType = req.VehicleIdType;
        }

        public UniqueId UUID { get; set; }

        public string sUUID { get { return UUID.ToString(); } }
    }

    //public class MyLinkRequest : LinkRequest
    //{
    //    public MyLinkRequest(UniqueId uuid, LinkRequest req)
    //    {
    //        this.CountryCode = req.CountryCode;
    //        this.ProviderId = req.ProviderId;
    //        this.UUID = uuid;
    //        this.VehicleId = req.VehicleId;
    //        this.VehicleIdType = req.VehicleIdType;
    //    }

    //    public UniqueId UUID { get; set; }

    //    public string sUUID { get { return UUID.ToString(); } }
    //}
}