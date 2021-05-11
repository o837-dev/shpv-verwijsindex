using Denion.WebService.VerwijsIndex;
using Denion.WebService.Database;
using NPRProxyService.Properties;
using System;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Data;


namespace NPRProxyService
{
    [LogBehavior]
    [ServiceBehavior(Name = "NPRProxy", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public class ProxyService : IVerwijsIndex
    {
        /**
         * Van Garage naar RDW/NPR
         **/
        PaymentStartResponse IVerwijsIndex.PaymentStart(PaymentStartRequest req)
        {
            PaymentStartResponse res = new PaymentStartResponse();

            // init RDW Client
            RDW.RegistrationClient client = Functions.RDWClient("02065", false);
            if(client == null) {
                res.RemarkId = "70";
                res.Remark = "NPR Provider server error";
            } else {

                //Omzetten vwx PaymentStart naar NPR PaymentStart
                RDW.PaymentStartRequest RDWreq = new RDW.PaymentStartRequest();
                RDW.PaymentStartResponseData RDWres = new RDW.PaymentStartResponseData();
                RDW.PaymentStartResponseError RDWerr = new RDW.PaymentStartResponseError();

                RDW.PaymentStartRequestData data = new RDW.PaymentStartRequestData();
                data.AreaManagerId = Functions.FixAreaManagerId(req.AreaManagerId);
                data.AreaId = req.AreaId;
                data.VehicleId = req.VehicleId;
                data.VehicleIdType = req.VehicleIdType;

                //SERV-299 Leave countrycode empty even if it is send by the garage.
                data.CountryCodeVehicleSpecified = false;
                data.StartDateTime = req.StartDateTime;
                data.EndDateTime = req.EndDateTime;
                data.EndDateTimeSpecified = req.EndDateTime != null;
                data.Amount = (decimal?)req.Amount;
                data.AmountSpecified = req.Amount != null;
                data.VAT = (decimal?)req.VAT;
                data.VATSpecified = req.VAT != null;

                if(req.Token != null) {
                    RDW.TokenListData tokenListData = new RDW.TokenListData {
                        Token = req.Token,
                        TokenType = req.TokenType
                    };
                    RDW.TokenListData[] tokenListDatas = new RDW.TokenListData[1];
                    tokenListDatas[0] = tokenListData;
                    data.TokenList = tokenListDatas;
                }


                RDWreq.PaymentStartRequestData = data;

                // Payment check naar NPR
                try {
                    // send the request to the RDW
                    RDWres = client.PaymentStart(Functions.GetPinFromCert(client.ClientCredentials.ClientCertificate.Certificate), data, out RDWerr);

                    res.ProviderId = RDWres.ProviderId != null && RDWres.ProviderId.Length == 4 ? "0" + RDWres.ProviderId : RDWres.ProviderId;//Hackwerk om NPR leading 0 te fixen
                    res.PaymentAuthorisationId = RDWres.PaymentAuthorisationId;
                    if(RDWres.AuthorisationMaxAmount.HasValue) {
                        res.AuthorisationMaxAmount = (double?)RDWres.AuthorisationMaxAmount.Value;
                    }
                    if(RDWres.AuthorisationMaxAmount.Value == 0) {
                        //Hack garages willen blijkbaar geen maxamount 0 accepteren
                        res.AuthorisationMaxAmount = null;
                    }
                    res.AuthorisationValidUntil = RDWres.EndDateTimeAdjusted;
                    res.Token = RDWres.TokenList[0]?.Token;
                    res.TokenType = RDWres.TokenList[0]?.TokenType;
                } catch(Exception ex) {
                    Database.Log(Settings.Default.ProviderId + "; Exception: " + ex.Message);
                    Database.Log(ex.StackTrace);
                }
            }

            return res;
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

            // init RDW Client
            RDW.RegistrationClient client = Functions.RDWClient("02065", false);
            if(client == null) {
                res.RemarkId = "70";
                res.Remark = "NPR Provider server error";
            } else {

                //Omzetten vwx paymentcheck naar NPR paymentcheck
                //TODO pin?
                RDW.PaymentCheckRequest RDWreq = new RDW.PaymentCheckRequest();
                RDW.PaymentCheckResponseData RDWres = new RDW.PaymentCheckResponseData();
                RDW.PaymentCheckResponseError RDWerr = new RDW.PaymentCheckResponseError();

                RDW.PaymentCheckRequestData data = new RDW.PaymentCheckRequestData();
                data.AreaManagerId = Functions.FixAreaManagerId(req.AreaManagerId);
                data.AreaId = req.AreaId;
                //data.SellingPointId = req.Sellingp
                data.VehicleId = req.VehicleId;
                data.VehicleIdType = req.VehicleIdType;

                //SERV-299 Leave countrycode empty even if it is send by the garage.
                data.CountryCodeSpecified = false;
                data.CheckDateTime = req.CheckDateTime;
              
                RDWreq.PaymentCheckRequestData = data;

                // Payment check naar NPR
                try {
                    // send the request to the RDW
                    RDWres = client.PaymentCheck(Functions.GetPinFromCert(client.ClientCredentials.ClientCertificate.Certificate), data, out RDWerr);

                    res.AreaId = RDWres.AreaId;
                    res.Granted = RDWres.Granted == RDW.IndicatorYNType.Y;
                    res.ProviderId = RDWres.ProviderId.Length == 4 ? "0" + RDWres.ProviderId : RDWres.ProviderId;//Hackwerk om NPR leading 0 te fixen
                } catch(Exception ex) {
                    Database.Log(Settings.Default.ProviderId + "; Exception: " + ex.Message);
                    Database.Log(ex.StackTrace);
                }
            }

            return res;
        }

        StatusResponse IVerwijsIndex.ServiceStatus()
        {
            return Service.ServiceStatus();
        }
    }
}
