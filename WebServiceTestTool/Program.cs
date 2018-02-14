using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace WebServiceTestTool
{

    class Program
    {
        static void Main(string[] args)
        {
            Tests t = new Tests();
            t.VerwijsindexPaymentCheckExternal();
        }
    }

    internal class Tests
    {
        internal void All()
        {
            WebSites();
            VerwijsindexPaymentExternal();
            VerwijsindexInternal();
            ParkeerregisterServices();
        }
        internal void WebSites()
        {
            Web.HttpCall("https://www.parkeerregister.nl/");
            Web.HttpCall("https://verwijsindex.shpv.nl/denion/",
                #region username/ password
                "htenhave", "V@kantie!!"
            #endregion
                );
            Web.HttpCall("http://gpk.shpv.nl/");
        }

        internal void ParkeerregisterServices()
        {
            parkeerregister.nl_Services_AdministrationService.AVGClient.WebserviceCheck("https://www.parkeerregister.nl/Services/Administration.svc");
        }

        internal void VerwijsindexPaymentExternal(string host = "https://verwijsindex.shpv.nl/")
        {
            string webApp = "Service";
            string endpoint = "/VerwijsIndexService.svc";

            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "" + endpoint);
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201404" + endpoint);
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201505" + endpoint);
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201702" + endpoint);

            //webApp = "Servicev2";
            //shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "" + endpoint);
            //shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201404" + endpoint);
            //shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201505" + endpoint);
            //shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201702" + endpoint);

            webApp = "Servicev4";
            //shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "" + endpoint);
            //shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201404" + endpoint);
            //shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201505" + endpoint);
            //shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201702" + endpoint);
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201709" + endpoint);

            shpv.nl_MonitorService.MonitorVWXClient.WebserviceCheck(host + "Monitor/MonitorVWX.svc");
        }

        internal void VerwijsindexPaymentCheckExternal(string host = "https://verwijsindex.shpv.nl/")
        {
            string webApp = "Service";
            string endpoint = "/VerwijsIndexService.svc";

            //nl.shpv_verwijsindex_201505.VerwijsIndexClient.PaymentCheck(host + webApp + "/201404" + endpoint);
            nl.shpv_verwijsindex_201505.VerwijsIndexClient.PaymentCheck(host + webApp + "/201505" + endpoint);
            nl.shpv_verwijsindex_201505.VerwijsIndexClient.PaymentCheck(host + webApp + "/201702" + endpoint); //werkt!

            //webApp = "Servicev2";
            //shpv.nl_Service_201404_verwijsindexservice.VerwijsIndexClient.PaymentCheck(host + webApp + "" + endpoint);
            //shpv.nl_Service_201404_verwijsindexservice.VerwijsIndexClient.PaymentCheck(host + webApp + "/201404" + endpoint);
            //shpv.nl_Service_201404_verwijsindexservice.VerwijsIndexClient.PaymentCheck(host + webApp + "/201505" + endpoint);
            //shpv.nl_Service_201404_verwijsindexservice.VerwijsIndexClient.PaymentCheck(host + webApp + "/201702" + endpoint);

            webApp = "Servicev4";
            //shpv.nl_Service_201404_verwijsindexservice.VerwijsIndexClient.PaymentCheck(host + webApp + "" + endpoint);
            //shpv.nl_Service_201404_verwijsindexservice.VerwijsIndexClient.PaymentCheck(host + webApp + "/201404" + endpoint);
            //shpv.nl_Service_201404_verwijsindexservice.VerwijsIndexClient.PaymentCheck(host + webApp + "/201505" + endpoint);
            //shpv.nl_Service_201404_verwijsindexservice.VerwijsIndexClient.PaymentCheck(host + webApp + "/201702" + endpoint);
            nl.shpv_verwijsindex_201709.VerwijsIndexClient.PaymentCheck(host + webApp + "/201709" + endpoint);
        }

        internal void VerwijsIndexDVM(string host = "http://hth-w2k8/")
        {
            string webApp = "Service";
            string endpoint = "/VerwijsIndexService.svc";

            /*
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "" + endpoint);
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201404" + endpoint);
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201505" + endpoint);
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201610" + endpoint);
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201701" + endpoint);*/
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201705" + endpoint);
        }

        internal void VerwijsindexInternal()
        {
            string host = "http://localhost/";
            string webApp = "";
            string endpoint = "/NPRProviderService.svc";

            webApp = "NPRTest";
            //shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + endpoint);
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201404" + endpoint);

            webApp = "NPRTestv4";
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + endpoint);

            webApp = "NPRProd";
            //shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + endpoint);
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201404" + endpoint);

            webApp = "NPRProdv4";
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + endpoint);


            webApp = "AVGProd";
            //shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + endpoint);
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + "/201404" + endpoint);

            webApp = "AVGProdv4";
            shpv.nl_Service_VerwijsIndexService.VerwijsIndexClient.PaymentStartCheck(host + webApp + endpoint);
        }
    }

    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class SoapContractBehavior : Attribute, IContractBehavior
    {
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            return;
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new DebugMessageInspector());
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            return;
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            return;
        }
    }

    public class DebugMessageInspector : IClientMessageInspector
    {
        private String remoteAddress = null;

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            Debug.WriteLine("<!--Received from: '" + remoteAddress + "'-->");
            if (reply.ToString().Length < 65536)
                Debug.WriteLine(reply.ToString());
            else
                Debug.WriteLine(reply.ToString().Substring(0, 65533) + "...");
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            remoteAddress = channel.RemoteAddress.Uri.ToString();
            Debug.WriteLine("<!--Sending to: '" + remoteAddress + "' -->");
            Debug.WriteLine(request.ToString());
            return null;
        }
    }

    public static class SSLExtensions
    {
        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors != System.Net.Security.SslPolicyErrors.None)
            {
                Debug.WriteLine("AcceptAllCertifications " + sslPolicyErrors);
                Console.WriteLine("AcceptAllCertifications " + sslPolicyErrors);
            }
            return true;
        }
    }

    public class Web
    {
        internal static void HttpCall(string URL, string username = null, string password = null)
        {
            // Create the request obj
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);

            // Set values for the request back
            req.Method = "GET";
            HttpWebResponse res = null;
            try
            {
                if (username != null)
                {
                    req.PreAuthenticate = true;
                    req.Credentials = new NetworkCredential(username, password);
                }

                res = (HttpWebResponse)req.GetResponse();
                StreamReader stIn = new StreamReader(res.GetResponseStream());
                string rv = stIn.ReadToEnd();
                stIn.Close();
                //res.StatusCode == HttpStatusCode.OK;

                Debug.WriteLine(URL + "> " + res.StatusCode + " / " + res.ContentLength);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + "> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(res.StatusCode + " / " + res.ContentLength);

            }
            catch (Exception ex)
            {
                if (res != null)
                {
                    Debug.WriteLine(URL + "> " + res.StatusCode + " / " + res.ContentLength + ": " + ex.Message);
                }
                else
                {
                    Debug.WriteLine(URL + "> " + ex.Message);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + "> ");
                Console.ForegroundColor = ConsoleColor.Red;

                if (res != null)
                {
                    Console.WriteLine(res.StatusCode + " / " + res.ContentLength + ": " + ex.Message);
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }

    internal class Param
    {
        internal static EndpointAddress GetEndPoint(string url)
        {
            return new EndpointAddress(url);
        }
    }

    internal class VWXParam : Param
    {
        internal static string AreaId = "GAR038AB1";
        internal static string AreaManagerId = "363PG";
        internal static string VehicleId = "18NKS1";
        internal static string CountryCode = "NL";
        internal static DateTime StartDateTime = DateTime.Parse("2017-12-22 14:12:19");
        internal static string AccessId = "WssTestTool";
        internal static string VehicleIdType = "LICENSE_PLATE";

        internal static WSHttpBinding GetWSBinding(string url)
        {
            WSHttpBinding myBinding = new WSHttpBinding();
            if (url.StartsWith("https"))
                myBinding.Security.Mode = SecurityMode.Transport;
            else
                myBinding.Security.Mode = SecurityMode.None;
            return myBinding;
        }
    }

    internal class QNPRParam : Param
    {
        #region hide
        internal static string Gebruikersnaam = "harmPM";
        internal static string Wachtwoord = "harm....";
        #endregion

        internal static BasicHttpBinding GetBasicBinding(string url)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            myBinding.MaxReceivedMessageSize = int.MaxValue;
            if (url.StartsWith("https"))
                myBinding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
            else
                myBinding.Security.Mode = BasicHttpSecurityMode.None;
            return myBinding;
        }
    }

    internal class MonitorParam : Param
    {
        internal static WebHttpBinding GetBasicBinding(string url)
        {
            WebHttpBinding myBinding = new WebHttpBinding();
            myBinding.MaxReceivedMessageSize = int.MaxValue;
            if (url.StartsWith("https"))
                myBinding.Security.Mode = WebHttpSecurityMode.Transport;
            else
                myBinding.Security.Mode = WebHttpSecurityMode.None;
            return myBinding;
        }
    }

}

namespace WebServiceTestTool.shpv.nl_MonitorService
{
    partial class MonitorVWXClient
    {
        internal static void WebserviceCheck(string URL)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(SSLExtensions.AcceptAllCertifications);
            MonitorVWXClient clnt = new MonitorVWXClient(MonitorParam.GetBasicBinding(URL), MonitorParam.GetEndPoint(URL));
            clnt.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());
            clnt.Endpoint.Behaviors.Add(new WebHttpBehavior());
            ConsoleColor fc = Console.ForegroundColor;
            try
            {
                var res = clnt.GetServiceStatus();

                Debug.WriteLine(URL + "> " + res.Status);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + "> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(res.Status);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(URL + "> " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + "> ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ForegroundColor = fc;
        }
    }
}

namespace WebServiceTestTool.shpv.nl_Service_VerwijsIndexService
{
    partial class VerwijsIndexClient
    {
        internal static void PaymentStartCheck(string URL)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(SSLExtensions.AcceptAllCertifications);
            VerwijsIndexClient service = new VerwijsIndexClient(VWXParam.GetWSBinding(URL), VWXParam.GetEndPoint(URL));
            //service.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());

            PaymentStartRequest req = new PaymentStartRequest();
            PaymentStartResponse res;

            req.AreaId = VWXParam.AreaId;
            req.AreaManagerId = VWXParam.AreaManagerId;
            req.StartDateTime = VWXParam.StartDateTime;
            req.CountryCode = VWXParam.CountryCode;
            req.VehicleId = VWXParam.VehicleId;
            req.AccessId = VWXParam.AccessId;
            
            ConsoleColor fc = Console.ForegroundColor;
            try
            {
                res = service.PaymentStart(req);

                Debug.WriteLine(URL + " " + res.Remark);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + " ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(res.Remark);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(URL + "> " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + "> ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ForegroundColor = fc;
        }    
    }
}

namespace WebServiceTestTool.nl.shpv_verwijsindex_201505
{
    partial class VerwijsIndexClient
    {
        internal static void PaymentCheck(string URL)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(SSLExtensions.AcceptAllCertifications);
            VerwijsIndexClient service = new VerwijsIndexClient(VWXParam.GetWSBinding(URL), VWXParam.GetEndPoint(URL));
            //service.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());

            PaymentCheckRequest req = new PaymentCheckRequest();
            PaymentCheckResponse res;

            req.AreaManagerId = VWXParam.AreaManagerId;
            req.AreaId = VWXParam.AreaId;
            req.VehicleId = VWXParam.VehicleId;
            req.CountryCode = VWXParam.CountryCode;
            req.CheckDateTime = VWXParam.StartDateTime;
            
            //string u = URL.Replace("VerwijsIndexService.svc", "");
            //u = u.Replace("https://verwijsindex.shpv.nl/Service", "");
            //u = u.Replace("/", "-");
            //req.Provider = "AVGPROD";
            req.VehicleIdType = VWXParam.VehicleIdType;

            ConsoleColor fc = Console.ForegroundColor;
            try
            {
                res = service.PaymentCheck(req);

                Debug.WriteLine(URL + " " + res.Remark);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + " ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(res.Remark);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(URL + "> " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + "> ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ForegroundColor = fc;
        }
    }
}


namespace WebServiceTestTool.nl.shpv_verwijsindex_201709
{
    partial class VerwijsIndexClient
    {
        internal static void PaymentCheck(string URL)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(SSLExtensions.AcceptAllCertifications);
            VerwijsIndexClient service = new VerwijsIndexClient(VWXParam.GetWSBinding(URL), VWXParam.GetEndPoint(URL));
            //service.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());

            PaymentCheckRequest req = new PaymentCheckRequest();
            PaymentCheckResponse res;

            req.AreaManagerId = VWXParam.AreaManagerId;
            req.AreaId = VWXParam.AreaId;
            req.VehicleId = VWXParam.VehicleId;
            req.CountryCode = VWXParam.CountryCode;
            req.CheckDateTime = VWXParam.StartDateTime;

            //string u = URL.Replace("VerwijsIndexService.svc", "");
            //u = u.Replace("https://verwijsindex.shpv.nl/Service", "");
            //u = u.Replace("/", "-");
            //req.Provider = "AVGPROD";
            req.VehicleIdType = VWXParam.VehicleIdType;

            ConsoleColor fc = Console.ForegroundColor;
            try
            {
                res = service.PaymentCheck(req);

                Debug.WriteLine(URL + " " + res.Remark);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + " ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(res.Remark);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(URL + "> " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + "> ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ForegroundColor = fc;
        }
    }
}

namespace WebServiceTestTool.shpv.nl_Service_201404_verwijsindexservice
{
    partial class VerwijsIndexClient
    {
        internal static void PaymentCheck(string URL)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(SSLExtensions.AcceptAllCertifications);
            VerwijsIndexClient service = new VerwijsIndexClient(VWXParam.GetWSBinding(URL), VWXParam.GetEndPoint(URL));
            //service.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());

            PaymentCheckRequest req = new PaymentCheckRequest();
            PaymentCheckResponse res;

            req.AreaManagerId = VWXParam.AreaManagerId;
            req.AreaId = VWXParam.AreaId;
            req.VehicleId = VWXParam.VehicleId;

            req.CheckDateTime = VWXParam.StartDateTime;
            req.CountryCode = VWXParam.CountryCode;
            string u = URL.Replace("VerwijsIndexService.svc", "");
            u = u.Replace("https://verwijsindex.shpv.nl/Service", "");
            //u = u.Replace("/", "-");

            //req.Provider = "AVGPROD";
            //req.VehicleId

            ConsoleColor fc = Console.ForegroundColor;
            try
            {
                res = service.PaymentCheck(req);

                Debug.WriteLine(URL + " " + res.Remark);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + " ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(res.Remark);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(URL + "> " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + "> ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ForegroundColor = fc;
        }
    }
}


namespace WebServiceTestTool.parkeerregister.nl_Services_AdministrationService
{
    partial class AVGClient
    {
        internal static void WebserviceCheck(string URL)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(SSLExtensions.AcceptAllCertifications);
            AVGClient service = new AVGClient(QNPRParam.GetBasicBinding(URL), QNPRParam.GetEndPoint(URL));
            //service.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());

            service.ClientCredentials.UserName.UserName = QNPRParam.Gebruikersnaam;
            service.ClientCredentials.UserName.Password = QNPRParam.Wachtwoord;
            StatusResponse res;
            ConsoleColor fc = Console.ForegroundColor;
            try
            {
                res = service.ServiceStatus();

                Debug.WriteLine(URL + "> " + res.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + "> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(res.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(URL + "> " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(URL + "> ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ForegroundColor = fc;
        }

    }
}