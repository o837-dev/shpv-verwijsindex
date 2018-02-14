using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsolApp
{
    class DoesWSMeetSpec
    {
		public string ToString(object obj)
        {
            Type t = obj.GetType();
            PropertyInfo[] props = t.GetProperties();
            
            String[] lines = new String[props.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = $"{props[i].Name}='{props[i].GetValue(obj)}'";
            }
            return string.Join(", ", lines);
        }

        public void CompareToDef(object obj, Type target)
        {
            Type t = obj.GetType();
            PropertyInfo[] props = t.GetProperties();
            PropertyInfo[] targetProps = target.GetProperties();

            for (int i = 0; i < props.Length; i++)
            {
                Console.WriteLine(props[i].Name + "?= " + targetProps[i].Name);
                //Console.WriteLine(props[i].CustomAttributes[0]);
                if (props[i].Name != targetProps[i].Name)
                {
                    Console.WriteLine("MisMatch!?");
                }
            }
        }

        public DoesWSMeetSpec()
        {
            String url = "http://dev.parkeergebouwenamsterdam.nl/service/v1/service.php";
            AltBasic(url);
			Console.Write("Press any key...");
            Console.ReadKey();
        }

        public void AltBasic(string url)
        {
            VerwijsIndexClient clnt = Service.ConsolePaymentClient(url);

            PaymentEndRequest endReq = new PaymentEndRequest()
            {
                Amount = 0.99,
                CountryCode = "NL",
                EndDateTime = DateTime.Now,
                PaymentAuthorisationId = "123ABC456DEF",
                ProviderId = "PRO123",
                VAT = 0.01,
                VehicleId = "TEST01",
                VehicleIdType = "LICENSE_PLATE"
            };

            CompareToDef(endReq, typeof(PaymentEndRequest));

            string data = string.Empty;
            try
            {
                PaymentEndResponse endRes = clnt.PaymentEnd(endReq);
            }
            catch (Exception ex)
            {
                data = ex.Message;
			}
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(data);
            XmlNode xnode= xdoc.SelectSingleNode("//*[local-name() = 'PaymentEndRequest']");
            foreach (XmlNode child in xnode.ChildNodes)
            {
                Console.WriteLine(child.Name);
            }
            Console.WriteLine("<-- SEND --> ");
            Console.WriteLine(data);

            string rv = WSCall(url, data);

            Console.WriteLine("<-- RECEIVED --> ");
            Console.WriteLine(rv);
            
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors != System.Net.Security.SslPolicyErrors.None)
            {
                if (sender.GetType() == typeof(System.Net.HttpWebRequest))
                {
                    System.Net.HttpWebRequest w = (System.Net.HttpWebRequest)sender;
                    Console.WriteLine("[AcceptAllCertifications]; Address: '" + w.Address + "', sslPolicyErrors: " + sslPolicyErrors);
                }
            }
            return true;
        }

        private string WSCall(string address, string message)
        {
            string text = null;

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(address);

            // Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/soap+xml";
            
            try
            {
                StreamWriter stOut = new StreamWriter(req.GetRequestStream(), Encoding.ASCII);
                stOut.Write(message);
                stOut.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            
            // Do the request to get the response
            try
            {
                WebResponse res = req.GetResponse();
                StreamReader stIn = new StreamReader(res.GetResponseStream());
                text = stIn.ReadToEnd();
                stIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return text;
        }

    public void Basic(string url)
        {
            ConsoleColor c = Console.ForegroundColor;
            VerwijsIndexClient clnt = Service.ConsolePaymentClient(url);

            PaymentCheckRequest chkReq = new PaymentCheckRequest()
            {
                AreaId = "TEST123",
                AreaManagerId = "TESTABC",
                CheckDateTime = DateTime.Now,
                CountryCode = "NL",
                VehicleId = "TEST01",
				Provider = "PRO123",
				VehicleIdType = "LICENSE_PLATE"
            };
            
            PaymentCheckResponse chkRes = clnt.PaymentCheck(chkReq);            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PaymentCheck: " + ToString(chkRes));
            Console.ForegroundColor = c;

            PaymentStartRequest staReq = new PaymentStartRequest()
            {
                AccessId = "ABC123",
                AreaId = "TEST123",
                AreaManagerId = "TESTABC",
                StartDateTime = DateTime.Now,
                CountryCode = "NL",
                VehicleId = "TEST01",
                Amount = 9.99,
                EndDateTime = DateTime.Now.AddHours(1),
				Token = "1234",
				TokenType = "PIN",
				VAT = 0.01, 
				VehicleIdType = "LICENSE_PLATE"
            };
            PaymentStartResponse staRes = clnt.PaymentStart(staReq);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PaymentStart: " + ToString(staRes));
            Console.ForegroundColor = c;

            PaymentEndRequest endReq = new PaymentEndRequest()
            {
                Amount = 0.99,
                CountryCode = "NL",
                EndDateTime = DateTime.Now,
                PaymentAuthorisationId = "123ABC456DEF",
                ProviderId = "PRO123",
                VAT = 0.01,
                VehicleId = "TEST01",
				VehicleIdType = "LICENSE_PLATE"
            };
            PaymentEndResponse endRes = clnt.PaymentEnd(endReq);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PaymentEnd: " + ToString(endRes));
            Console.ForegroundColor = c;
        }
    }
}
