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

        

        internal static RegistrationClient RDWClient()
        {
            return RDWClient(GetCertificate(Properties.Settings.Default.CertFile, Properties.Settings.Default.CertPin));
        }
        internal static RegistrationClient RDWClient(string provider)
        {

            return CustomRDWClient(GetCertificate(provider));
        }

        internal static RegistrationClient RDWClient(X509Certificate2 cert)
        {
            RegistrationClient client = null;

            // intantiate the client and the URL 
            try
            {
                client = new RegistrationClient();
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

        internal static RegistrationClient CustomRDWClient(X509Certificate2 cert)
        {
            RegistrationClient client = null;

            // intantiate the client and the URL 
            try
            {
                string url = ConfigurationManager.AppSettings["EndPoint"];

                HttpsTransportBindingElement httpsBinding = new HttpsTransportBindingElement();
                httpsBinding.RequireClientCertificate = true;

                TextMessageEncodingBindingElement encoding = new TextMessageEncodingBindingElement();
                encoding.MessageVersion = MessageVersion.Soap11WSAddressing10;
                CustomBinding binding = new CustomBinding(encoding, httpsBinding);

                client = new RegistrationClient(binding, Service.GetEndPoint(url ?? Properties.Settings.Default.EndPoint));
                client.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());
                client.ClientCredentials.ClientCertificate.Certificate = cert;
            }
            catch (Exception ex)
            {
                Database.Database.Log("CLNT; EX: " + ex.Message + "; STACK: " + ex.StackTrace);
            }

            return client;
        }

        internal static X509Certificate2 GetCertificate(string certFile, string certPin)
        {
            X509Certificate2 cert = null;
            try
            {
                Database.Database.Log("GetCert Local config " + certFile + "; pin: " + Rijndael.Decrypt(certPin));
                cert = new X509Certificate2(certFile, Rijndael.Decrypt(certPin), X509KeyStorageFlags.MachineKeySet);
            }
            catch (Exception ex)
            {
                Database.Database.Log("CERT; EX: " + ex.Message + "; STACK: " + ex.StackTrace);
            }
            return cert;
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
                Database.Database.Log("GetCert NPRPlusCert DB " + certificate + "; pin: " + Rijndael.Decrypt(certPin));
                cert = new X509Certificate2(certificate, Rijndael.Decrypt(certPin), X509KeyStorageFlags.MachineKeySet);
            }
            return cert;
        }

        internal static string GetPinFromCert()
        {
            return GetPinFromCert(GetCertificate(Properties.Settings.Default.CertFile, Properties.Settings.Default.CertPin));
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