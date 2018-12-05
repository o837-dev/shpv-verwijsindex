using Denion.WebService.Cryptography;
using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;

namespace Denion.WebService
{
    public class Functions
    {
        public static DateTime ToUTC(DateTime dat)
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            return localZone.ToUniversalTime(dat);
        }

        public static DateTime DateTimeToLocalTimeZone(DateTime dat)
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            return localZone.ToLocalTime(dat);
        }

        public static RDWRight RDWEnrollRight(string providerID, string areaManagerId, string areaId, string usageId, string vehicleId, DateTime startDateTime, DateTime? endDateTime, string countryCode, Decimal? amount, Decimal? vat, string reference)
        {
            //Database.Database.Log("Provider: " + Settings.Default.ProviderId + "; Received: " + req.VehicleId);
            RDWRight right = new RDWRight();

            // init RDW Client
            RDW.RegistrationClient client = RDWClient(providerID);
            if (client == null)
            {
                right.Remark = "Failed to init RegistrationClient";
            }
            else
            {
                // create the request en responses
                RDW.PSRightEnrollRequestData RDWreq = new RDW.PSRightEnrollRequestData();
                RDW.PSRightEnrollResponseError RDWerr = new RDW.PSRightEnrollResponseError();
                RDW.PSRightEnrollResponseData RDWres = null;

                // setup geo info
                GEOinfo geo = GEO.FromArea(areaManagerId, areaId);
                if (geo == null || (geo.lat == 0 && geo.lon == 0))
                {
                    RDWreq.AreaId = areaId;
                    RDWreq.AreaManagerId = FixAreaManagerId(areaManagerId);
                }
                else
                {
                    RDWreq.LocationPSRight = new RDW.PSRightEnrollRequestDataLocationPSRight()
                    {
                        Latitude = geo.lat,
                        Longitude = geo.lon
                    };
                }
                //RDWreq.SellingPointId  // NOT used

                RDWreq.UsageId = usageId;
                RDWreq.VehicleId = vehicleId;

                RDWreq.StartTimePSright = ToUTC(startDateTime);
                if (endDateTime.HasValue)
                {
                    RDWreq.EndTimePSright = ToUTC(endDateTime.Value);
                    RDWreq.EndTimePSrightSpecified = true;
                }

                if (!string.IsNullOrEmpty(countryCode))
                {
                    string cc = countryCode.ToUpper();
                    if (Enum.IsDefined(typeof(RDW.UneceLandCodesType), cc))
                    {
                        RDWreq.CountryCodeVehicle = (RDW.UneceLandCodesType)Enum.Parse(typeof(RDW.UneceLandCodesType), cc, true);
                        RDWreq.CountryCodeVehicleSpecified = true;
                    }
                    //else
                    //{
                    //    Database.Log("LC; CountryCode '" + cc + "' is not valid");
                    //    res.Remark = "NPR Provider server error; Invalid or unknown Country code";
                    //    res.RemarkId = "75";
                    //    return res;
                    //}
                }

                //RDWreq.PSRightWindowList

                if (amount.HasValue)
                {
                    RDWreq.AmountPSright = amount.Value;
                    RDWreq.AmountPSrightSpecified = true;
                }
                if (vat.HasValue)
                {
                    RDWreq.VATPSright = vat.Value;
                    RDWreq.VATPSrightSpecified = true;
                }

                if (!string.IsNullOrEmpty(reference))
                    RDWreq.ReferencePSRight = reference.Substring(0, Math.Min(reference.Length, 40));

                try
                {
                    // send the request to the RDW
                    RDWres = client.EnrollPSRight(GetPinFromCert(client.ClientCredentials.ClientCertificate.Certificate), RDWreq, out RDWerr);
                }
                catch (Exception ex)
                {
                    Database.Database.Log(Properties.Settings.Default.ProviderId + "; Exception: " + ex.Message);
                }


                // Handle the response
                if (RDWerr != null)
                {
                    Database.Database.Log("RDWERR; CODE: " + RDWerr.ErrorCode + "; DESC: " + RDWerr.ErrorDesc);
                    right.Remark = "RDWERR; CODE: " + RDWerr.ErrorCode + "; DESC: " + RDWerr.ErrorDesc;
                }
                else if (RDWres != null)
                {
                    //RDWres.AmountPSRightCalculated
                    //RDWres.AmountPSRightCalculatedSpecified
                    //RDWres.AreaId
                    //RDWres.AreaManagerId
                    //RDWres.EndTimePSRightAdjusted
                    //RDWres.EndTimePSRightAdjustedSpecified
                    right.PSRightId = RDWres.PSRightId;
                    //RDWres.PSRightRemarkList
                    //RDWres.SellingPointId
                    //RDWres.SpecifCalcAmountList
                    //RDWres.VATPSRightCalculated
                    //RDWres.VATPSRightCalculatedSpecified                    
                }
            }
            return right;
        }

        public static string RDWRevokeRight(string providerID, string PSRightID, DateTime endDateTime)
        {
            RDW.RegistrationClient client = RDWClient(providerID);
            if (client == null)
            {
                return "Failed to init RegistrationClient";
            }
            else
            {
                // create the request en responses
                RDW.PSRightRevokeRequestData RDWreq = new RDW.PSRightRevokeRequestData();
                RDW.PSRightRevokeResponseError RDWerr = new RDW.PSRightRevokeResponseError();
                RDW.PSRightRevokeResponseData RDWres = null;

                RDWreq.EndTimePSRight = ToUTC(endDateTime);
                RDWreq.PSRightId = PSRightID;

                try
                {
                    // send the request to the RDW
                    RDWres = client.RevokePSRight(GetPinFromCert(client.ClientCredentials.ClientCertificate.Certificate), RDWreq, out RDWerr);

                }
                catch (Exception ex)
                {
                    Database.Database.Log(Properties.Settings.Default.ProviderId + "; Exception: " + ex.Message);
                    return ex.Message;
                }

                // Handle the response
                if (RDWerr != null)
                {
                    Database.Database.Log("RDWERR; CODE: " + RDWerr.ErrorCode + "; DESC: " + RDWerr.ErrorDesc);
                    return "RDWERR; CODE: " + RDWerr.ErrorCode + "; DESC: " + RDWerr.ErrorDesc;
                }
                else if (RDWres != null)
                {
                    //RDWres.AmountPSRightCalculated
                    //RDWres.AmountPSRightCalculatedSpecified
                    //RDWres.EndTimePSRightAdjusted
                    //RDWres.EndTimePSRightAdjustedSpecified
                    //RDWres.PSRightRemarkList
                    //RDWres.SpecifCalcAmountList
                    //RDWres.VATPSRightCalculated
                    //RDWres.VATPSRightCalculatedSpecified
                    return "Oke";
                }
            }
            return null;
        }

        internal static RDW.RegistrationClient RDWClient(string provider)
        {

            return CustomRDWClient(GetCertificate(provider));
        }

        internal static RDW.RegistrationClient RDWClient(X509Certificate2 cert)
        {
            RDW.RegistrationClient client = null;

            // intantiate the client and the URL 
            try
            {
                client = new RDW.RegistrationClient();
                client.Endpoint.Address = new EndpointAddress(Properties.Settings.Default.EndPoint);
                client.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());
                client.ClientCredentials.ClientCertificate.Certificate = cert;
            }
            catch (Exception ex)
            {
                Database.Database.Log("CLNT; EX: " + ex.Message + "; STACK: " + ex.StackTrace);
            }

            return client;
        }

        internal static RDW.RegistrationClient CustomRDWClient(X509Certificate2 cert)
        {
            RDW.RegistrationClient client = null;

            // intantiate the client and the URL 
            try
            {
                string url = ConfigurationManager.AppSettings["EndPoint"];

                HttpsTransportBindingElement httpsBinding = new HttpsTransportBindingElement();
                httpsBinding.RequireClientCertificate = true;

                TextMessageEncodingBindingElement encoding = new TextMessageEncodingBindingElement();
                encoding.MessageVersion = MessageVersion.Soap11WSAddressing10;
                CustomBinding binding = new CustomBinding(encoding, httpsBinding);

                client = new RDW.RegistrationClient(binding, Service.GetEndPoint(url ?? Properties.Settings.Default.EndPoint));
                client.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());
                client.ClientCredentials.ClientCertificate.Certificate = cert;
            }
            catch (Exception ex)
            {
                Database.Database.Log("CLNT; EX: " + ex.Message + "; STACK: " + ex.StackTrace);
            }

            return client;
        }

        internal static X509Certificate2 GetCertificate(string provider)
        {
            X509Certificate2 cert = null;
            SqlCommand com = new SqlCommand();
            com.CommandText = "SELECT top 1 [CERTIFICATE], [CERTPIN] FROM [ProviderNPRCertificate] where PROVIDER=@PROVIDER and CURRENT_TIMESTAMP between  [VALIDFROM] and [VALIDUNTIL]";
            com.Parameters.Add("@PROVIDER", SqlDbType.NVarChar, 100).Value = provider;

            DataTable dt = Database.Database.ExecuteQuery(com);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                byte[] certificate = dr["CERTIFICATE"] as byte[];
                string certPin = dr["CERTPIN"] as string;
                cert = new X509Certificate2(certificate, Rijndael.Decrypt(certPin), X509KeyStorageFlags.MachineKeySet);
            }
            return cert;
        }

        internal static string GetPinFromCert(X509Certificate2 CERT)
        {
            string _pin = null;

            foreach (string subject in CERT.Subject.Split(','))
            {
                string[] kv = subject.Split('=');
                if (kv.Length > 1)
                {
                    if (kv[0].Trim() == "O")
                    {
                        _pin = kv[1].Trim();
                        break;
                    }
                }
            }
            return _pin;
        }

        internal static string FixAreaManagerId(string AreaManagerId)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "SELECT [AreaManagerIdTo] from AreaManagerIdFix where [AreaManagerIdFrom] = @AreaManagerIdFrom";
            com.Parameters.Add("@AreaManagerIdFrom", SqlDbType.NVarChar, 200).Value = AreaManagerId;

            DataTable dt = Database.Database.ExecuteQuery(com);
            if (dt != null && dt.Rows.Count == 1)
            {
                return dt.Rows[0]["AreaManagerIdTo"].ToString();
            }
            return AreaManagerId;
        }
    }

    public class RDWRight
    {
        public string PSRightId { get; set; }
        public string Remark { get; set; }
    }

    class NPRRight
    {

        public string PSRightIdField { get; set; }

        //public string AreaManagerIdField { get; set; }

        //public string AreaIdField { get; set; }

        //public string SellingPointIdField { get; set; }

        //public DateTime? EndTimePSRightAdjustedField { get; set; }

        //public decimal? AmountPSRightCalculatedField { get; set; }

        //public decimal? VATPSRightCalculatedField { get; set; }

        //public SpecifCalcAmountData[] SpecifCalcAmountListField { get; set; }

        //public PSRightRemarkData[] PSRightRemarkListField { get; set; }

    }
    class NPRRightCheck
    {
        public string RemarkId { get; set; }
        public string Remark { get; set; }
        public string AreaId { get; set; }
        public string PaymentAuthorisationId { get; set; }
        public DateTime AuthorisationValidUntil { get; set; }
    }

}