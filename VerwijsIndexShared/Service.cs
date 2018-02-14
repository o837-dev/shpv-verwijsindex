﻿using Denion.WebService.Database;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

namespace Denion.WebService.VerwijsIndex
{
    /// <summary>
    /// Internal helper class om verbindingen naar providers op te zetten
    /// </summary>
    public class Service
    {
        /// <summary>
        /// helper functie om niet ondertekende ssl certificaten te accepteren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certification"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors != System.Net.Security.SslPolicyErrors.None)
            {
                if (sender.GetType() == typeof(System.Net.HttpWebRequest))
                {
                    System.Net.HttpWebRequest w = (System.Net.HttpWebRequest)sender;
                    Database.Database.Log(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name + " [AcceptAllCertifications]; Address: '" + w.Address + "', sslPolicyErrors: " + sslPolicyErrors);
                }
            }

            return true;
        }

        /// <summary>
        /// Create the binding based upon the address
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static WSHttpBinding GetBinding(string url)
        {
            WSHttpBinding myBinding = new WSHttpBinding();
            if (url.StartsWith("https"))
                myBinding.Security.Mode = SecurityMode.Transport;
            else
                myBinding.Security.Mode = SecurityMode.None;
            return myBinding;
        }

        /// <summary>
        /// Create an endpoint address with the address
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static EndpointAddress GetEndPoint(string url)
        {
            return new EndpointAddress(url);
        }

        /// <summary>
        /// returns a verwijsindex client for the specified URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static VerwijsIndexClient PaymentClient(string url)
        {
            //Handle unsigned certificates
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            VerwijsIndexClient clnt = new VerwijsIndexClient(GetBinding(url), GetEndPoint(url));
            clnt.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());
            return clnt;
        }

        /// <summary>
        /// alternative verwijsindex client, sends messages to console instead of Database
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static VerwijsIndexClient ConsolePaymentClient(string url)
        {
            //Handle unsigned certificates
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            VerwijsIndexClient clnt = new VerwijsIndexClient(GetBinding(url), GetEndPoint(url));
            clnt.Endpoint.Contract.Behaviors.Add(new ConsoleSoapContractBehavior());
            return clnt;
        }

        /// <summary>
        /// returns a provider client for the specified URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static ProviderClient LinkClient(string url)
        {
            //Handle unsigned certificates
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            ProviderClient clnt = new ProviderClient(GetBinding(url), GetEndPoint(url));
            clnt.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());
            return clnt;
        }

        /// <summary>
        /// returns a consumer client for the specified URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static ConsumerClient Consumer(string url)
        {
            //Handle unsigned certificates
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            ConsumerClient clnt = new ConsumerClient(GetBinding(url), GetEndPoint(url));
            clnt.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());
            return clnt;
        }

        public static TransportBindingElement GetTransportBinding(string url)
        {
            TransportBindingElement myBinding = null;
            if (url.StartsWith("https"))
                myBinding = new HttpsTransportBindingElement();
            else
                myBinding = new HttpTransportBindingElement();
            return myBinding;
        }

        /// <summary>
        /// returns a NPR registration client for the specified URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static RegistrationClient NPRLikeClient (string url)
        {
            //Handle unsigned certificates
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            //HttpsTransportBindingElement httpsBinding = new HttpsTransportBindingElement();
            //httpsBinding.RequireClientCertificate = true;
            TransportBindingElement binder = GetTransportBinding(url);

            TextMessageEncodingBindingElement encoding = new TextMessageEncodingBindingElement();
            encoding.MessageVersion = MessageVersion.Soap11WSAddressing10;
            CustomBinding binding = new CustomBinding(encoding, binder);

            RegistrationClient clnt = new RegistrationClient(binding, GetEndPoint(url));
            clnt.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());
            return clnt;
        }

        public static RegistrationPlusClient NPRPlusClient(string url)
        {
            //Handle unsigned certificates
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            //HttpsTransportBindingElement httpsBinding = new HttpsTransportBindingElement();
            //httpsBinding.RequireClientCertificate = true;
            TransportBindingElement binder = GetTransportBinding(url);

            TextMessageEncodingBindingElement encoding = new TextMessageEncodingBindingElement();
            encoding.MessageVersion = MessageVersion.Soap11WSAddressing10;
            CustomBinding binding = new CustomBinding(encoding, binder);

            RegistrationPlusClient clnt = new RegistrationPlusClient(binding, GetEndPoint(url));
            clnt.Endpoint.Contract.Behaviors.Add(new SoapContractBehavior());
            return clnt;
        }

        public static StatusResponse ServiceStatus()
        {
            Timing t = new Timing("ServiceStatus", IncomingAddress(), OperationContextAddress());
            StatusResponse res = new StatusResponse();

            res.Message = "Ok";

            try
            {
                using (SqlCommand cmd = new SqlCommand("Select CURRENT_TIMESTAMP"))
                {
                    object sqlRv = Database.Database.ExecuteScalar(cmd);
                    if (sqlRv != null && sqlRv.GetType() == (typeof(System.Exception)))
                    {
                        res.Message = "DB - fail";
                    }
                    else
                    {
                        //PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                        //PerformanceCounter ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

                        //float cpuLoad = cpuCounter.NextValue();
                        //float ramLoad = ramCounter.NextValue();

                        //Thread.Sleep(1000);
                        //// Altijd dubbel meten om een referentie waarde te krijgen
                        //// we kunnen hier 1 seconde wachten of we moeten hem lifetime initialiseren..
                        //// @See https://msdn.microsoft.com/en-us/library/system.diagnostics.performancecounter.nextvalue.aspx
                        //cpuLoad = cpuCounter.NextValue();
                        //ramLoad = ramCounter.NextValue();

                        ////res.Message = "CPU: " + cpuLoad + "% ";
                        //if (cpuLoad > 80)
                        //    res.Message = "High CPU";
                        //else
                        //{
                        //    //res.Message += "RAM: " + ramLoad + "%";
                        //    if (ramLoad > 90)
                        //        res.Message = "Low memory";
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
            }

            res.CheckTime = DateTime.Now;
            t.Finish();
            return res;
        }

        public static string IncomingAddress()
        {
            string rv = string.Empty;
            try
            {
                OperationContext context = OperationContext.Current;
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                rv = endpoint.Address;
            }
            catch (Exception ex)
            {
                rv = ex.Message;
            }
            if (string.IsNullOrEmpty(rv)) rv = "Unknown";
            return rv;
        }

        public static string OperationContextAddress()
        {
            string rv = string.Empty;
            try
            {
                OperationContext context = OperationContext.Current;
                rv = context.IncomingMessageProperties.Via.OriginalString;
            }
            catch (Exception ex)
            {
                rv = ex.Message;
            }

            if (string.IsNullOrEmpty(rv)) rv = "Unknown";
            return rv;
        }

        /// <summary>
        /// Standaard is de random niet random genoeg, door hem te initialiseren met een random seed gaat het een stuk beter 
        /// </summary>
        public static Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);


    }
}