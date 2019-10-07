using Denion.WebService.Cryptography;
using Denion.WebService.Database;
using Denion.WebService.Properties;
using Denion.WebService.VerwijsIndex;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace Denion.WebService
{
    [LogBehavior]
    [ServiceBehavior(Name = "NPRProvider", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public class NPRProviderService : IVerwijsIndex
    {
        PaymentStartResponse IVerwijsIndex.PaymentStart(PaymentStartRequest req)
        {
            //Database.Database.Log("Provider: " + Settings.Default.ProviderId + "; Received: " + req.VehicleId);

            // prepare the answer
            PaymentStartResponse res = new PaymentStartResponse();
            res.ProviderId = Settings.Default.ProviderId;
            res.Remark = "";
            res.RemarkId = "";
            res.Token = "RDW";

            // init RDW Client
            RDW.RegistrationClient client = Functions.RDWClient(Settings.Default.ProviderId, false);
            if (client == null)
            {
                res.Remark = "NPR Provider server error";
                res.RemarkId = "70";
            }

            // create the request
            RDW.PSRightCheckRequestData RDWreq = new RDW.PSRightCheckRequestData();
            RDW.PSRightCheckResponseError RDWerr = new RDW.PSRightCheckResponseError();
            RDW.PSRightCheckResponseData RDWres = null;

            GEOinfo geo = GEO.FromArea(req.AreaManagerId, req.AreaId);
            if (geo == null || (geo.lat == 0 && geo.lon == 0))
            {
                RDWreq.AreaId = req.AreaId;
                RDWreq.AreaManagerId = Functions.FixAreaManagerId(req.AreaManagerId);
            }
            else
            {
                RDWreq.CheckLocation = new RDW.PSRightCheckRequestDataCheckLocation()
                {
                    Latitude = geo.lat,
                    Longitude = geo.lon
                };
            }
            //RDWreq.CheckAddress //  NOT used

            RDWreq.CheckTime = Functions.ToUTC(req.StartDateTime);

            if (!string.IsNullOrEmpty(req.CountryCode))
            {
                string cc = req.CountryCode.ToUpper();
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
            RDWreq.ExtraInfoIndicator = RDW.IndicatorYNType.Y;
            if (!string.IsNullOrEmpty(req.AccessId))
                RDWreq.ReferenceCheckOrg = req.AccessId;

            RDWreq.UsageId = Settings.Default.UsageId;
            RDWreq.VehicleId = req.VehicleId;
            //req.VAT //    NOT used
            //req.Amount // NOT used

            try
            {
                // send the request to the RDW
                RDWres = client.CheckPSRight(Rijndael.Decrypt(Settings.Default.MsgPin), RDWreq, out RDWerr);

            }
            catch (Exception ex)
            {
                Database.Database.Log(Settings.Default.ProviderId + "; Exception: " + ex.Message);
            }


            // Handle the response
            if (RDWerr != null)
            {
                Database.Database.Log("RDWERR; CODE: " + RDWerr.ErrorCode + "; DESC: " + RDWerr.ErrorDesc);
                res.Remark = "NPR provider service error";
                res.RemarkId = "80";
            }
            else if (RDWres != null)
            {
                if (RDWres.CheckAnswer == RDW.IndicatorYNType.y || RDWres.CheckAnswer == RDW.IndicatorYNType.Y)
                {
                    if (RDWres.InformationalMessage != null)
                    {
                        Database.Database.Log("RDWINF; CODE: " + RDWres.InformationalMessage.ErrorCode + "; DESC: " + RDWres.InformationalMessage.ErrorDesc);

                        res.PaymentAuthorisationId = Functions.GenerateUniqueId().ToString();
                        res.Remark = "NPR provider service message; " + RDWres.InformationalMessage.ErrorDesc;
                        res.RemarkId = "90";
                    }
                    else if (RDWres.PSRightCheckPSRightList != null)
                    {
                        RDW.PSRightCheckPSRightData right = RDWres.PSRightCheckPSRightList[0];

                        //res.AuthorisationMaxAmount 
                        if (right.EndTimePSRightAdjusted.HasValue)
                            res.AuthorisationValidUntil = Functions.DateTimeToLocalTimeZone(right.EndTimePSRightAdjusted.Value);
                        else if (right.EndTimePSRight.HasValue)
                            res.AuthorisationValidUntil = Functions.DateTimeToLocalTimeZone(right.EndTimePSRight.Value);

                        res.PaymentAuthorisationId = Functions.GenerateUniqueId().ToString();
                        // res.PaymentAuthorisationId = DateTime.Now.ToFileTime().ToString() + "_" + right.PSRightId; Generaties kind of GUID

                        CreateRegistration(req, res.PaymentAuthorisationId);
                    }
                }
            }

            return res;
        }

        PaymentEndResponse IVerwijsIndex.PaymentEnd(PaymentEndRequest req)
        {
            PaymentEndResponse res = new PaymentEndResponse();
            res.PaymentAuthorisationId = req.PaymentAuthorisationId;
            res.Remark = "NPR provider service; PaymentStop does not affect the permit";
            res.RemarkId = "85";

            UpdateRegistration(req);

            return res;
        }

        PaymentCheckResponse IVerwijsIndex.PaymentCheck(PaymentCheckRequest req)
        {
            PaymentCheckResponse res = new PaymentCheckResponse();

            //res.ProviderId = Settings.Default.ProviderId;
            res.Remark = "";
            res.RemarkId = "";
            
            try
            {
                //Denion.WebService.Database.Database.Log("Provider: " + Settings.Default.ProviderId + "; Received: " + req.VehicleId);
                
                NPRRightCheck check = RDWCheck(req.AreaId, req.AreaManagerId, req.CheckDateTime, req.CountryCode, null, req.VehicleId);
                if (!string.IsNullOrEmpty(check.Remark))
                {
                    res.Remark = check.Remark;
                    res.RemarkId = check.RemarkId;
                }
                else if (check.PaymentAuthorisationId != null)
                {
                    if (res.Granted.HasValue && res.Granted.Value)
                    {
                        // was goed en is geldig in NPR
                    }
                    else
                    {
                        // was niet bekend, maar is wel geldig in NPR
                        res.Granted = true;
                        res.AreaId = check.AreaId;
                        res.ProviderId = Settings.Default.ProviderId;
                    }
                }
                else
                {
                    if (res.Granted.HasValue && res.Granted.Value)
                    {
                        // was goed en is NIET geldig in NPR
                        res.Granted = false;
                    }
                    else
                    {
                        // was niet geldig en is NIET geldig in NPR
                    }
                }
            }
            catch (Exception e)
            {
                Database.Database.Log("PaymentCheck error; " + e.Message + "; " + e.StackTrace);
                res.Remark = "NPR Provider server error";
                res.RemarkId = "100";
            }

            return res;
        }

        StatusResponse IVerwijsIndex.ServiceStatus()
        {
            return Service.ServiceStatus();
        }

        private NPRRightCheck RDWCheck(string areaId, string areaManagerId, DateTime startDateTime, string countryCode, string accessId, string vehicleId)
        {
            //Database.Database.Log("Provider: " + Settings.Default.ProviderId + "; Received: " + req.VehicleId);
            NPRRightCheck check = new NPRRightCheck();

            // init RDW Client
            RDW.RegistrationClient client = Functions.RDWClient(Settings.Default.ProviderId, false);
            if (client == null)
            {
                check.RemarkId = "70";
                check.Remark = "NPR Provider server error";
            }
            else
            {
                // create the request
                RDW.PSRightCheckRequestData RDWreq = new RDW.PSRightCheckRequestData();
                RDW.PSRightCheckResponseError RDWerr = new RDW.PSRightCheckResponseError();
                RDW.PSRightCheckResponseData RDWres = null;

                GEOinfo geo = GEO.FromArea(areaManagerId, areaId);
                if (geo == null || (geo.lat == 0 && geo.lon == 0))
                {
                    RDWreq.AreaId = areaId;
                    RDWreq.AreaManagerId = Functions.FixAreaManagerId(areaManagerId);
                }
                else
                {
                    RDWreq.CheckLocation = new RDW.PSRightCheckRequestDataCheckLocation()
                    {
                        Latitude = geo.lat,
                        Longitude = geo.lon
                    };
                }
                //RDWreq.CheckAddress //  NOT used
                RDWreq.CheckTime = Functions.ToUTC(startDateTime);

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
                RDWreq.ExtraInfoIndicator = RDW.IndicatorYNType.Y;
                if (!string.IsNullOrEmpty(accessId))
                    RDWreq.ReferenceCheckOrg = accessId;

                RDWreq.UsageId = Settings.Default.UsageId;
                RDWreq.VehicleId = vehicleId;
                //req.VAT //    NOT used
                //req.Amount // NOT used

                try
                {
                    // send the request to the RDW
                    RDWres = client.CheckPSRight(Rijndael.Decrypt(Settings.Default.MsgPin), RDWreq, out RDWerr);

                }
                catch (Exception ex)
                {
                    Database.Database.Log(Settings.Default.ProviderId + "; Exception: " + ex.Message);
                }


                // Handle the response
                if (RDWerr != null)
                {
                    Database.Database.Log("RDWERR; CODE: " + RDWerr.ErrorCode + "; DESC: " + RDWerr.ErrorDesc);

                    check.RemarkId = "80";
                    check.Remark = "NPR provider service error";
                }
                else if (RDWres != null)
                {
                    if (RDWres.CheckAnswer == RDW.IndicatorYNType.y || RDWres.CheckAnswer == RDW.IndicatorYNType.Y)
                    {
                        if (RDWres.InformationalMessage != null)
                        {
                            Database.Database.Log("RDWINF; CODE: " + RDWres.InformationalMessage.ErrorCode + "; DESC: " + RDWres.InformationalMessage.ErrorDesc);

                            check.PaymentAuthorisationId = "NPRPS_" + Hashing.CalculateMD5Hash(areaId + vehicleId + startDateTime.ToFileTime().ToString());
                            check.Remark = "NPR provider service message; " + RDWres.InformationalMessage.ErrorDesc;
                            check.RemarkId = "90";
                        }
                        else if (RDWres.PSRightCheckPSRightList != null)
                        {
                            RDW.PSRightCheckPSRightData right = RDWres.PSRightCheckPSRightList[0];

                            //res.AuthorisationMaxAmount 
                            if (right.EndTimePSRightAdjusted.HasValue)
                                check.AuthorisationValidUntil = Functions.DateTimeToLocalTimeZone(right.EndTimePSRightAdjusted.Value);
                            else if (right.EndTimePSRight.HasValue)
                                check.AuthorisationValidUntil = Functions.DateTimeToLocalTimeZone(right.EndTimePSRight.Value);

                            check.PaymentAuthorisationId = DateTime.Now.ToFileTime().ToString() + "_" + right.PSRightId;
                            check.AreaId = right.AreaId;
                        }
                    }
                }
            }
            return check;
        }
      
        private void CreateRegistration(PaymentStartRequest req, string AuthorisationId)
        {
            if (!Settings.Default.AVG) return;

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

            com.Parameters.Add("@STARTDATETIME", SqlDbType.DateTime).Value = getCorrectDateTime(req.StartDateTime);

            
     
            //Database.ExecuteScalar(com, true, ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString);
            DatabaseQueue.Add(new QueueObject(com, true, string.Format(ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString, Environment.MachineName)));
        }

        private void UpdateRegistration(PaymentEndRequest req)
        {
            if (!Settings.Default.AVG) return;

            SqlCommand com = new SqlCommand();
            com.CommandText =
                "Update Administration set UPDATED=@UPDATED, ENDDATETIME=@ENDDATETIME where VEHICLEID=@VEHICLEID and COUNTRYCODE=@COUNTRYCODE and AUTHORISATIONID=@AUTHORISATIONID";
   
            com.Parameters.Add("@UPDATED", SqlDbType.DateTime).Value = DateTime.Now;
            com.Parameters.Add("@ENDDATETIME", SqlDbType.DateTime).Value = getCorrectDateTime(req.EndDateTime);

            com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Rijndael.Encrypt(req.VehicleId);
            if (!string.IsNullOrEmpty(req.CountryCode))
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = req.CountryCode;
            else
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = "";

            com.Parameters.Add("@AUTHORISATIONID", SqlDbType.NVarChar, 50).Value = req.PaymentAuthorisationId;

            //Database.ExecuteScalar(com, true, ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString);
            DatabaseQueue.Add(new QueueObject(com, true, string.Format(ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString, Environment.MachineName)));
        }

        public DateTime getCorrectDateTime(DateTime dateTime)
        {
            // Current date and time
            DateTime now = DateTime.Now;
            // Get difference with now
            TimeSpan difference = now.Subtract(dateTime);
            // If the difference is greather then an hour (because you can't start a payment in the future)
            if (difference.Hours > 0)
            {
                // Add difference 
                return dateTime.AddHours(difference.Hours);
            }
            else
            {
                // Normal time
                return dateTime;
            }
        }
    }
}