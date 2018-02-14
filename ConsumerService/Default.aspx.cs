using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Linq;
using System.Xml;
using System.Web;

namespace ConsumerService
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtRemark.Text = ConfigurationManager.AppSettings["Remark"];
                txtRemarkId.Text = ConfigurationManager.AppSettings["RemarkId"];
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
            int iReqs = 0;

            if (Application["reqlist"] != null)
            {
                Dictionary<UniqueId, CancelAuthorisationRequest> reqs = (Dictionary<UniqueId, CancelAuthorisationRequest>)Application["reqlist"];
                iReqs += reqs.Count;

                var res = from r in reqs select new MyCancelAuthorisationRequest(r.Key, r.Value);
                GridView1.DataSource = res;
                GridView1.DataBind();
            }
            if (Application["aareqlist"] != null)
            {
                Dictionary<UniqueId, ActivateAuthorisationRequest> aareqs = (Dictionary<UniqueId, ActivateAuthorisationRequest>)Application["aareqlist"];
                iReqs += aareqs.Count;

                var res = from r in aareqs select new MyActivateAuthorisationRequest(r.Key, r.Value);
                GridView2.DataSource = res;
                GridView2.DataBind();
            }

            if (iReqs > 0)
                Title = "(" + iReqs + ") " + "ConsumerService";
            else
                Title = "ConsumerService";
        }
        private Dictionary<string, string> ValuesFromRow(GridViewRow row)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                string key = GridView1.Columns[i].HeaderText;
                string value = HttpUtility.HtmlDecode(row.Cells[i].Text).Trim();
                if (!string.IsNullOrEmpty(key))
                    dic.Add(key, value);
            }
            return dic;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int idx = int.Parse(e.CommandArgument.ToString());
            //Dictionary<string, string> dic = ValuesFromRow(GridView1.Rows[idx]);
            //UniqueId uid = new UniqueId (dic["UUID"]);
            UniqueId uid = new UniqueId(e.CommandArgument.ToString());
            Dictionary<UniqueId, CancelAuthorisationRequest> reqlist = (Dictionary<UniqueId, CancelAuthorisationRequest>)Application["reqlist"];
            Dictionary<UniqueId, CancelAuthorisationResponse> reslist = (Dictionary<UniqueId, CancelAuthorisationResponse>)Application["reslist"];

            CancelAuthorisationRequest req = reqlist[uid];
            CancelAuthorisationResponse res = new CancelAuthorisationResponse();

            if (e.CommandName == "Grant")
            {
                //res.CanceledDateTime = req.CancelDateTime;
                res.EndTimeAdjusted = req.CancelDateTime;
                res.Granted = true;
            }
            else if (e.CommandName == "GrantNow")
            {
                //res.CanceledDateTime = DateTime.Now;
                res.StartTimeAdjusted = DateTime.Now.AddHours(-1);
                res.EndTimeAdjusted = DateTime.Now;
                res.Granted = true;

            }
            else if (e.CommandName == "Revoke")
            {
                //res.CanceledDateTime = null;//req.CancelDateTime;
                res.Granted = false;
            }

            res.PaymentAuthorisationId = req.PaymentAuthorisationId;
            res.ProviderId = req.ProviderId;
            res.Remark = txtRemark.Text;
            res.RemarkId = txtRemarkId.Text;
            res.Amount = double.Parse(txtAmount.Text);
            res.VAT = double.Parse(txtVAT.Text);
            reslist.Add(uid, res);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            TimerStatusUpdate.Enabled = !TimerStatusUpdate.Enabled;
            btnRefresh.Text = (TimerStatusUpdate.Enabled) ? "Stop refresh" : "Auto refresh";
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            UniqueId uid = new UniqueId(e.CommandArgument.ToString());

            Dictionary<UniqueId, ActivateAuthorisationRequest> aareqlist = (Dictionary<UniqueId, ActivateAuthorisationRequest>)System.Web.HttpContext.Current.Application["aareqlist"];
            Dictionary<UniqueId, ActivateAuthorisationResponse> aareslist = (Dictionary<UniqueId, ActivateAuthorisationResponse>)System.Web.HttpContext.Current.Application["aareslist"];


            ActivateAuthorisationRequest req = aareqlist[uid];
            ActivateAuthorisationResponse res = new ActivateAuthorisationResponse();
            
            if (e.CommandName == "Grant")
            {
                //res.CanceledDateTime = req.CancelDateTime;
                res.Granted = true;
                res.PaymentAuthorisationId = Guid.NewGuid().ToString();
            }
            else if (e.CommandName == "GrantNow")
            {
                res.StartDateTimeAdjusted = DateTime.Now;
                res.Granted = true;
                res.PaymentAuthorisationId = Guid.NewGuid().ToString();
            }
            else if (e.CommandName == "Revoke")
            {
                //res.CanceledDateTime = null;//req.CancelDateTime;
                res.Granted = false;
            }

            res.ProviderId = req.ProviderId;
            res.Remark = txtRemark.Text;
            res.RemarkId = txtRemarkId.Text;
            
            aareslist.Add(uid, res);

        }
    }
    public class MyCancelAuthorisationRequest : CancelAuthorisationRequest
    {
        public MyCancelAuthorisationRequest(UniqueId uuid, CancelAuthorisationRequest req)
        {
            this.AreaId = req.AreaId;
            this.AreaManagerId = req.AreaManagerId;
            this.CancelDateTime = req.CancelDateTime;
            this.CountryCode = req.CountryCode;
            this.UUID = uuid;
            this.PaymentAuthorisationId = req.PaymentAuthorisationId;
            this.ProviderId= req.ProviderId;
            this.VehicleId = req.VehicleId;
            this.VehicleIdType = req.VehicleIdType;
        }

        public UniqueId UUID { get; set; }

        public string sUUID { get { return UUID.ToString(); } }
    }

    public class MyActivateAuthorisationRequest : ActivateAuthorisationRequest
    {
        public MyActivateAuthorisationRequest(UniqueId uuid, ActivateAuthorisationRequest req)
        {
            this.AreaId = req.AreaId;
            this.AreaManagerId = req.AreaManagerId;
            this.CountryCode = req.CountryCode;
            this.UUID = uuid;
            this.PaymentAuthorisationId = req.PaymentAuthorisationId;
            this.ProviderId = req.ProviderId;
            this.VehicleId = req.VehicleId;
            this.VehicleIdType = req.VehicleIdType;
        }

        public UniqueId UUID { get; set; }

        public string sUUID { get { return UUID.ToString(); } }
    }
}
