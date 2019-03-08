using System;
using System.Web.UI;
using System.ServiceModel;
using System.Configuration;
using Denion.WebService.VerwijsIndex;

namespace GarageClient
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            UpdateImages("in", "closed");
            divUitrijden.Visible = false;
            txtKenteken.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + imgPark.ClientID + "').click();return false;}} else {return true}; ");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
        }

        protected void imgPark_Click(object sender, ImageClickEventArgs e){
            VerwijsIndexClient clnt = Service.PaymentClient(ConfigurationManager.AppSettings["VerwijsIndexURL"]);

            long? antwoord = null; string err = null;
            string direction; string state;
            getState(out direction, out state);
            if (direction == "in") {
                state = "opened";

                PaymentCheckRequest pcreq = new PaymentCheckRequest();
                pcreq.AreaId = txtArea.Text;
                pcreq.AreaManagerId = txtAreaManagerId.Text;
                pcreq.CheckDateTime= DateTime.Now;
                pcreq.CountryCode = txtLandcode.Value;
                pcreq.VehicleId = txtKenteken.Value;
                pcreq.VehicleIdType = txtKentekenType.Value;
                //pcreq.Provider = txtProviderId.Text;
                PaymentCheckResponse pcres = clnt.PaymentCheck(pcreq);
                if (pcres.Granted.HasValue)
                {
                    if (!pcres.Granted.Value)
                    {
                        err = "CHECK: NO";
                        state = "closed";
                    }
                    else
                    {
                        PaymentStartRequest req = new PaymentStartRequest();
                        PaymentStartResponse res = null;
                        req.VehicleId = txtKenteken.Value;
                        req.VehicleIdType = txtKentekenType.Value;
                        req.AccessId = txtAccessId.Text;
                        req.AreaManagerId = txtAreaManagerId.Text;
                        req.AreaId = txtArea.Text;
                        req.CountryCode = txtLandcode.Value;
                        req.StartDateTime = DateTime.Now;
                        res = clnt.PaymentStart(req);

                        if (res.PaymentAuthorisationId != null)
                            antwoord = res.PaymentAuthorisationId.Value;
                        else if (res.Remark != null)
                            err = res.Remark;
                    }
                }
                else
                {
                    err = pcres.Remark;
                }
            }
            else if (direction == "out")//  && state == "closed")
            {
                PaymentEndRequest req = new PaymentEndRequest();
                PaymentEndResponse res = null;
                req.VehicleId = txtKenteken.Value;
                req.VehicleIdType = txtKentekenType.Value;
                req.EndDateTime = DateTime.Now;
                req.CountryCode = txtLandcode.Value;
                req.ProviderId = txtProviderId.Text;
                req.PaymentAuthorisationId = long.Parse(txtPaymentAuthorisationId.Text);
                req.Amount = 0.79;
                req.VAT = 0.21;
                res = clnt.PaymentEnd(req);

                if (res.PaymentAuthorisationId != null)
                {
                    state = "opened";
                    antwoord = res.PaymentAuthorisationId;
                }
                else if (!string.IsNullOrEmpty(res.Remark))
                    err = res.Remark;
            }

            UpdateImages(direction, state);
            if (err != null)
            {
                srv01.Value = "ERR: " + err;
                exclamination.Attributes.CssStyle["display"] = "block";
            }
            else if (antwoord != null)
            {
                srv01.Value = "OK: " + antwoord;

                kaartje.Attributes.CssStyle["display"] = "none";
            }
            else
            {
                kaartje.Attributes.CssStyle["display"] = "block";

                if (direction == "in")
                {
                    srv01.Value = "Geen Provider gevonden";
                    kaartje.Src = "res/parkeerkaartje.jpg";
                }
                else
                {
                    srv01.Value = "Betaal anders";
                    kaartje.Src = "res/euro.jpg";
                }
            }

            if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                clnt.Close();
        }

        private void UpdateImages(string direction, string state)
        {
            srv01.Value = "";

            gate.Attributes["class"] = direction + "_" + state;
            if (direction == "in")
            {
                btnIn.CssClass = "btnDirection active";
                btnOut.CssClass = "btnDirection inactive";
            }
            else
            {
                btnIn.CssClass = "btnDirection inactive";
                btnOut.CssClass = "btnDirection active";
            }

            prov01.Visible = true;

            kaartje.Attributes.CssStyle["display"] = "none";
            exclamination.Attributes.CssStyle["display"] = "none";
        }

        private void getState(out string direction, out string state)
        {
            if (gate.Attributes["class"] != null)
            {
                string dirAndState = gate.Attributes["class"];
                direction = dirAndState.Split('_')[0];
                state = dirAndState.Split('_')[1];
            }
            else
            {
                direction = null;
                state = null;
            }
        }

        protected void btnIn_Click(object sender, EventArgs e)
        {
            UpdateImages("in", "closed");
            divUitrijden.Visible = false;
        }

        protected void btnOut_Click(object sender, EventArgs e)
        {
            UpdateImages("out", "closed");
            divUitrijden.Visible = true;
        }
    }
}
