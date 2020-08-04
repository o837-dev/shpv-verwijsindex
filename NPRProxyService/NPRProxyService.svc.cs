using Denion.WebService.VerwijsIndex;
using Denion.WebService.Cryptography;
using Denion.WebService.Database;
using Denion.WebService.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace NPRProxyService
{
    [LogBehavior]
    [ServiceBehavior(Name = "NPRProxy", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public class ProxyService : IVerwijsIndex
    {
        PaymentStartResponse IVerwijsIndex.PaymentStart(PaymentStartRequest req)
        {
            return new PaymentStartResponse();
        }

        PaymentEndResponse IVerwijsIndex.PaymentEnd(PaymentEndRequest req)
        {
            PaymentEndResponse res = new PaymentEndResponse();
            res.PaymentAuthorisationId = req.PaymentAuthorisationId;

            String providerId = findProviderByAuthorisationId(req.PaymentAuthorisationId);
            if (providerId == null)
            {
                res.Remark = "Proxy kan geen providerId vinden voor " + req.PaymentAuthorisationId;
                res.RemarkId = "PROXY002";
            }

            // init RDW Client
            RDW.RegistrationClient client = Functions.RDWClient(providerId, false);
            if (client == null)
            {
                res.RemarkId = "70";
                res.Remark = "NPR Provider server error";
            }
            else
            {
                
                //Omzetten vwx paymentEnd naar NPR paymentEnd
                //TODO pin?
                RDW.PaymentEndRequest RDWreq = new RDW.PaymentEndRequest();
                RDW.PaymentEndResponseData RDWres = new RDW.PaymentEndResponseData();
                RDW.PaymentEndResponseError RDWerr = new RDW.PaymentEndResponseError();

                RDW.PaymentEndRequestData data = new RDW.PaymentEndRequestData();
                data.PaymentAuthorisationId = req.PaymentAuthorisationId;
                data.EndDateTime = req.EndDateTime;
                
                if (req.Amount != null)
                {
                    Database.Log(Settings.Default.ProviderId + "; Amount: " + req.Amount);
                    data.AmountSpecified = true;
                    data.Amount = decimal.Truncate((decimal)req.Amount * 100)/100;
                }
                if (req.VAT != null)
                {
                    Database.Log(Settings.Default.ProviderId + "; VAT: " + req.VAT);
                    data.VATSpecified = true;
                    data.VAT = decimal.Truncate((decimal)req.VAT*100)/100;
                }
                //data.ProviderId = providerId;
                RDWreq.PaymentEndRequestData = data;

                // Payment end naar NPR
                try
                {
                    // send the request to the RDW
                    RDWres = client.PaymentEnd(Functions.GetPinFromCert(client.ClientCredentials.ClientCertificate.Certificate), data, out RDWerr);

                }
                catch (Exception ex)
                {
                    Database.Log(Settings.Default.ProviderId + "; Exception: " + ex.Message);
                    Database.Log(ex.StackTrace);
                }
            }
            
            return res;
        }

        private string findProviderByAuthorisationId(string authorisationId)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "SELECT PROVIDERID from Authorisation where AUTHORISATIONID=@AUTHORISATIONID";
            com.Parameters.Add("@AUTHORISATIONID", SqlDbType.NVarChar, 50).Value = authorisationId;

            DataTable dt = Database.ExecuteQuery(com);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    Provider p = new Provider(dr);

                    return p.id;
                }
            }
            return null;
        }

        PaymentCheckResponse IVerwijsIndex.PaymentCheck(PaymentCheckRequest req)
        {
            PaymentCheckResponse res = new PaymentCheckResponse();
            
            res.Remark = "PaymentCheck not yet implemented";
            res.RemarkId = "PROXY001";

            return res;
        }

        StatusResponse IVerwijsIndex.ServiceStatus()
        {
            return Service.ServiceStatus();
        }
    }
}
