using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.ServiceModel;

namespace GarageClient
{
    public class RawRequest
    {
        public RawRequest(string msg)
        {
            Message = msg;
        }

        public string Message { get; set; }
        public string Result { get; set; }
        public string Error { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public class Utilities
    {
        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors != System.Net.Security.SslPolicyErrors.None)
            {
                if (sender.GetType() == typeof(System.Net.HttpWebRequest))
                {
                    System.Net.HttpWebRequest w = (System.Net.HttpWebRequest)sender;
                    Denion.WebService.Database.Database.Log(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name + " [AcceptAllCertifications]; Address: '" + w.Address + "', sslPolicyErrors: " + sslPolicyErrors);
                }
            }
            return true;
        }
        
        public static void SendAndReceive(string addrress, bool wcf, ref RawRequest request)
        {
            if (wcf)
                SendAndReceive(addrress, "application/soap+xml", ref request);
            else
                SendAndReceive(addrress, "text/xml; charset=utf-8", ref request);
        }

        public static void SendAndReceive(string addrress, string contentType, ref RawRequest request)
        {
            //Handle unsigned certificates
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            // Create the request obj
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(addrress);

            // Set values for the request back
            req.Method = "POST";
            req.ContentType = contentType;
            req.ContentLength = request.Message.Length;

            DateTime t1 = DateTime.Now;
            // Write the request
            try
            {
                StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                stOut.Write(request.Message);
                stOut.Close();
            }
            catch (Exception ex)
            {
                request.Error = ex.Message;
            }

            // Do the request to get the response
            try
            {
                StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
                request.Result = stIn.ReadToEnd();
                stIn.Close();
            }
            catch (Exception ex)
            {
                request.Error = ex.Message;
            }

            DateTime t2 = DateTime.Now;
            request.Duration = (t2 - t1);
        }
    }
}
