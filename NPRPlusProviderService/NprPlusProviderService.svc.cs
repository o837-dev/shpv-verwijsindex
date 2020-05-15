using Denion.WebService;
using Denion.WebService.Cryptography;
using Denion.WebService.Database;
using NPRPlusProviderService.Properties;
using Denion.WebService.VerwijsIndex;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Activation;

using System.Diagnostics;
using System.Net.Mail;
using System.Configuration;
using System.Net.Mime;
using System.Text;
using System.Reflection;
using System.ServiceModel;

namespace NPRPlusProviderService
{
    [LogBehavior]
    [ServiceBehavior(Name = "Registration", Namespace = "http://rdw.nl/rpv/1.0")]
    public class NprPlusProviderService : INprPlus
    {
        public ActivateEnrollRequestResponse ActivateEnroll(ActivateEnrollRequestRequest request)
        {
            ActivateEnrollRequestResponseData data = new ActivateEnrollRequestResponseData();
            ActivateEnrollRequestResponseError error = null;

            data.AuthorisationMaxAmount = -0.01;
            data.ProviderId = ConfigurationManager.AppSettings["ProviderId"];
            //data.Remark = "string";
            //data.RemarkId = "string";
            //data.Token = "string";
            //data.TokenType = "string";

            PSRightCheckResponse checkRes = RDWCheck("WITTELIJST", "02065", request.ActivateEnrollRequestRequestData.StartDateTime, null, null, request.ActivateEnrollRequestRequestData.VehicleId);
            PSRightCheckResponseError RDWerr = checkRes.PSRightCheckResponseError;
            PSRightCheckResponseData RDWres = checkRes.PSRightCheckResponseData;

            // Handle the response
            if (RDWerr != null) {
                Database.Log("RDWERR; CODE: " + RDWerr.ErrorCode + "; DESC: " + RDWerr.ErrorDesc);

                Database.Log("RDWERR; CODE: " + RDWerr.ErrorCode + "; DESC: " + RDWerr.ErrorDesc);
                data.Remark = "NPR provider service error";
                data.RemarkId = "20";
            } else if (RDWres != null) {    
                if (RDWres.CheckAnswer == IndicatorYNType.y || RDWres.CheckAnswer == IndicatorYNType.Y) {
                    if (RDWres.InformationalMessage != null) {
                        Database.Log("RDWINF; CODE: " + RDWres.InformationalMessage.ErrorCode + "; DESC: " + RDWres.InformationalMessage.ErrorDesc);

                        data.PaymentAuthorisationId = Denion.WebService.Functions.GenerateUniqueId().ToString();
                        data.Remark = "NPR provider service message; " + RDWres.InformationalMessage.ErrorDesc;
                        data.RemarkId = "90";
                    } else if (RDWres.PSRightCheckPSRightList != null) {
                        PSRightCheckPSRightData right = RDWres.PSRightCheckPSRightList[0];

                        //res.AuthorisationMaxAmount 
                        if (right.EndTimePSRightAdjusted.HasValue)
                            data.AuthorisationValidUntil = Denion.WebService.Functions.DateTimeToLocalTimeZone(right.EndTimePSRightAdjusted.Value);
                        else if (right.EndTimePSRight.HasValue)
                            data.AuthorisationValidUntil = Denion.WebService.Functions.DateTimeToLocalTimeZone(right.EndTimePSRight.Value);

                        // Generate unique ID
                        data.PaymentAuthorisationId = Denion.WebService.Functions.GenerateUniqueId().ToString();

                        CreateRegistration(request.ActivateEnrollRequestRequestData, data.PaymentAuthorisationId);
                    }
                }
            }

            return new ActivateEnrollRequestResponse(data, error);
        }

        public PSRightCheckResponse CheckPSRight(PSRightCheckRequest request) {
            PSRightCheckRequestData req = request.PSRightCheckRequestData;
            PSRightCheckResponse res = new PSRightCheckResponse();

            try {
                Database.Log("Provider: " + Settings.Default.ProviderId + "; Received: " + req.VehicleId);

                res = RDWCheck("WITTELIJST", "02065", req.CheckTime, null, null, req.VehicleId);
                   
                //res.PSRightCheckResponseData.CheckAnswer = RDWres.PSRightCheckResponseData.CheckAnswer;
                //res.AreaId = check.AreaId;
                //res.ProviderId = Settings.Default.ProviderId;
                
            } catch (Exception e) {
                Database.Log("CheckPSRight error; " + e.Message + "; " + e.StackTrace);
                //res.Remark = "NPR Provider server error";
                //res.RemarkId = "100";
            }


            return res;
        }

        public RevokedByThirdPartyRequestResponse RevokedByThirdParty(RevokedByThirdPartyRequestRequest request) {
            RevokedByThirdPartyRequestResponseData data = new RevokedByThirdPartyRequestResponseData();
            RevokedByThirdPartyRequestResponseError error = null;
            
            data.PaymentAuthorisationId = request.RevokedByThirdPartyRequestRequestData.PaymentAuthorisationId;


            UpdateRegistration(request.RevokedByThirdPartyRequestRequestData);
            SendEmail("RevokedByThirdPartyRequest Received", BuildObjectGrid(request.RevokedByThirdPartyRequestRequestData), ConfigurationManager.AppSettings["BezwaarBeroep.QNPRProviderEmail"]);
            return new RevokedByThirdPartyRequestResponse(data, error);
        }

        public static void SendEmail(string subject, string message, string to) {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["BezwaarBeroep.SMTPHost"]))
                Log.Write("BezwaarBeroep.SMTPHost empty, not sending email", EventLogEntryType.Warning);
            else {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["BezwaarBeroep.SMTPHost"];
                smtp.Port = ConfigurationManager.AppSettings["BezwaarBeroep.SMTPPort"] != "" ? int.Parse(ConfigurationManager.AppSettings["BezwaarBeroep.SMTPPort"]) : 25;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(String.Format(ConfigurationManager.AppSettings["BezwaarBeroep.SMTPFrom"], Environment.MachineName), "Parkeerregister.nl");
                mail.To.Add(to);

                mail.Subject = subject;
                mail.IsBodyHtml = true;
                message = message.Replace(Environment.NewLine, "<br />");
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(message, new ContentType("text/html"));

                mail.AlternateViews.Add(htmlView);

                //mail.Body = message;

                try {
                    smtp.Send(mail);
                } catch (Exception ex) {
                    Log.Write(ex.ToString(), EventLogEntryType.Error);
                }
            }
        }

        public string BuildObjectGrid(Object o) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='childTable'>");

            if (o.GetType().BaseType == typeof(Array)) {
                sb.Append("<tr>");
                sb.Append("<td>");

                Array array = (Array)o;
                foreach (var item in array) {
                    sb.Append(BuildObjectGrid(item));
                }

                sb.Append("</td>");
                sb.Append("</tr>");

            } else {
                // print all properties of object
                foreach (PropertyInfo prop in o.GetType().GetProperties()) {
                    // 11-04-2012 ADJ hide all fields ending with specified to save space
                    if (!prop.ToString().EndsWith("Specified")) // header check
                    {
                        object value = prop.GetValue(o, null);
                        if (value != null)  // empty prop value => don't show
                        {
                            // only print properties with values
                            sb.Append(BuildMyObjectRow(o, prop));
                        } else {
                        }
                    }
                }
            }

            sb.Append("</table>");

            return sb.ToString();
        }

        protected string BuildMyObjectRow(object o, PropertyInfo prop) {
            StringBuilder sb = new StringBuilder();
            int cntr = 0;
            sb.Append("<tr>");

            object value = prop.GetValue(o, null);
            if ((prop.PropertyType.BaseType == typeof(Array)) && (value != null)) {
                int id = cntr++;
                sb.Append("<td class='simhead' onclick=\"expand(this, 'cell_" + id + "');\">" + prop.Name + " [+]</td>");

                sb.Append("<td id='cell_" + id + "'  style='display: none;' >");
                sb.Append(BuildObjectGrid(value));
            } else if ((prop.PropertyType.BaseType == typeof(Object)) && (prop.PropertyType.Namespace.StartsWith("RDW")) && (value != null)) {
                int id = cntr++;
                sb.Append("<td class='simhead' onclick=\"expand(this, 'cell_" + id + "');\">" + prop.Name + " [+]</td>");

                sb.Append("<td id='cell_" + id + "'  style='display: none;' >");
                sb.Append(BuildObjectGrid(value));
            } else {
                string name = prop.Name;
                sb.Append("<td class='simhead'>" + name + "</td>");

                sb.Append("<td class='simbody'>");
                if (value == null) value = "";
                sb.Append(ObjectToString(value));
            }
            sb.Append("</td>");
            sb.Append("</tr>");
            return sb.ToString();
        }

        protected string BuildMyObjectRow(string key, object value) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr>");

            string name = name = key;
            sb.Append("<td class='simhead'>" + name + "</td>");

            sb.Append("<td class='simbody'>");
            if (value == null) value = "";
            sb.Append(ObjectToString(value));

            sb.Append("</td>");
            sb.Append("</tr>");
            return sb.ToString();
        }

        protected string ObjectToString(object o) {
            string localValue = null;
            if (o.GetType() == typeof(DateTime)) {
                DateTime currentUTC = Denion.WebService.Functions.DateTimeToLocalTimeZone(DateTime.Parse(o.ToString()));
                localValue = currentUTC.ToShortDateString() + " " + currentUTC.ToShortTimeString();
            } else {
                localValue = o.ToString();
            }
            return localValue;
        }

        internal static class Log {
            private static EventLog _eventLog;

            static Log() {
                string source = "QNPR service";
                string logName = "Application";
                _eventLog = new EventLog();
                if (!EventLog.SourceExists(source)) {
                    EventLog.CreateEventSource(source, logName);
                }
                _eventLog.Source = source;
                _eventLog.Log = logName;
            }

            public static void Write(string text, EventLogEntryType type) {
                if (Debugger.IsAttached) {
                    Debug.WriteLine(DateTime.Now.ToLongTimeString() + " [" + type.ToString().Substring(0, 1) + "] " + text);
                }
                //Alert.Notify("[" + type.ToString().Substring(0, 1) + "] Uw aandacht voor het volgende", text, "h.tenhave@ictspirit.nl");
                _eventLog.WriteEntry(text, type);

            }

        }


        private void CreateRegistration(ActivateEnrollRequestRequestData req, string AuthorisationId)
        {
            if (ConfigurationManager.AppSettings["AVG"].ToLower() == "false")
                return;

            SqlCommand com = new SqlCommand();
            com.CommandText =
                "insert into Administration (CREATED, AREAMANAGERID, AREAID, VEHICLEID, COUNTRYCODE, ACCESSID, AUTHORISATIONID, STARTDATETIME) values " +
                "  (@CREATED, @AREAMANAGERID, @AREAID, @VEHICLEID, @COUNTRYCODE, @ACCESSID, @AUTHORISATIONID, @STARTDATETIME)";
            com.Parameters.Add("@CREATED", SqlDbType.DateTime).Value = DateTime.Now;
            com.Parameters.Add("@AREAMANAGERID", SqlDbType.NVarChar, 200).Value = req.AreaManagerId;
            com.Parameters.Add("@AREAID", SqlDbType.NVarChar, 200).Value = req.AreaId;
            com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Rijndael.Encrypt(req.VehicleId);
            if (!string.IsNullOrEmpty(req.CountryCode))
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = req.CountryCode;
            else
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = "";
            if (!string.IsNullOrEmpty(req.AccessId))
                com.Parameters.Add("@ACCESSID", SqlDbType.NVarChar, 50).Value = req.AccessId;
            else
                com.Parameters.Add("@ACCESSID", SqlDbType.NVarChar, 50).Value = "";
            com.Parameters.Add("@AUTHORISATIONID", SqlDbType.NVarChar, 50).Value = AuthorisationId;
            com.Parameters.Add("@STARTDATETIME", SqlDbType.DateTime).Value = req.StartDateTime;

            DatabaseQueue.Add(new QueueObject(com, true, string.Format(ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString, Environment.MachineName)));
        }

        private void UpdateRegistration(RevokedByThirdPartyRequestRequestData req)
        {
            if (ConfigurationManager.AppSettings["AVG"].ToLower() == "false")
                return;

             SqlCommand com = new SqlCommand();
            com.CommandText =
                "Update Administration set UPDATED=@UPDATED, ENDDATETIME=@ENDDATETIME where VEHICLEID=@VEHICLEID and COUNTRYCODE=@COUNTRYCODE and AUTHORISATIONID=@AUTHORISATIONID";

            com.Parameters.Add("@UPDATED", SqlDbType.DateTime).Value = DateTime.Now;
            com.Parameters.Add("@ENDDATETIME", SqlDbType.DateTime).Value = req.EndDateTime;

            com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Rijndael.Encrypt(req.VehicleId);
            if (!string.IsNullOrEmpty(req.CountryCode))
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = req.CountryCode;
            else
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = "";

            com.Parameters.Add("@AUTHORISATIONID", SqlDbType.NVarChar, 50).Value = req.PaymentAuthorisationId;

            DatabaseQueue.Add(new QueueObject(com, true, string.Format(ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString, Environment.MachineName)));
        }

        private PSRightCheckResponse RDWCheck(string areaId, string areaManagerId, DateTime startDateTime, string countryCode, string accessId, string vehicleId) {
            //Database.Database.Log("Provider: " + Settings.Default.ProviderId + "; Received: " + req.VehicleId);
            PSRightCheckResponse res = new PSRightCheckResponse();

            // init RDW Client
            RegistrationClient client = Denion.WebService.Functions.RDWClient();
            if (client == null) {
                //check.RemarkId = "70";
                //check.Remark = "NPR Provider server error";
            } else {
                // create the request
                PSRightCheckRequestData RDWreq = new PSRightCheckRequestData();
                PSRightCheckResponseError RDWerr = new PSRightCheckResponseError();
                PSRightCheckResponseData RDWres = null;

                GEOinfo geo = GEO.FromArea(areaManagerId, areaId);
                if (geo == null || (geo.lat == 0 && geo.lon == 0)) {
                    RDWreq.AreaId = areaId;
                    RDWreq.AreaManagerId = Denion.WebService.Functions.FixAreaManagerId(areaManagerId);
                } else {
                    RDWreq.CheckLocation = new PSRightCheckRequestDataCheckLocation() {
                        Latitude = geo.lat,
                        Longitude = geo.lon
                    };
                }
                //RDWreq.CheckAddress //  NOT used
                RDWreq.CheckTime = Denion.WebService.Functions.ToUTC(startDateTime);

                if (!string.IsNullOrEmpty(countryCode)) {
                    string cc = countryCode.ToUpper();
                    if (Enum.IsDefined(typeof(RDW.UneceLandCodesType), cc)) {
                        RDWreq.CountryCodeVehicle = (UneceLandCodesType)Enum.Parse(typeof(UneceLandCodesType), cc, true);
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
                RDWreq.ExtraInfoIndicator = IndicatorYNType.Y;
                if (!string.IsNullOrEmpty(accessId))
                    RDWreq.ReferenceCheckOrg = accessId;

                RDWreq.UsageId = Settings.Default.UsageId;
                RDWreq.VehicleId = vehicleId;
                //req.VAT //    NOT used
                //req.Amount // NOT used

                try {
                    // send the request to the RDW
                    Database.Log("sending NPR+ " + ConfigurationManager.AppSettings["ServiceId"]);
                    RDWres = client.CheckPSRight(Rijndael.Decrypt(Settings.Default.MsgPin), RDWreq, out RDWerr);

                } catch (Exception ex) {
                   Database.Log(Settings.Default.ProviderId + "; Exception: " + ex.Message);
                }


                // Handle the response
                res.PSRightCheckResponseData = RDWres;
                res.PSRightCheckResponseError = RDWerr;
            }
            return res;
        }
    }
}
