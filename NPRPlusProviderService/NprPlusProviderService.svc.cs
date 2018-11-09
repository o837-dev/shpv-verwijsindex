using Denion.WebService;
using Denion.WebService.Cryptography;
using Denion.WebService.Database;
using Denion.WebService.Properties;
using Denion.WebService.VerwijsIndex;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Activation;

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

                        data.PaymentAuthorisationId = "NPRPS_" + Hashing.CalculateMD5Hash(request.ActivateEnrollRequestRequestData.AreaId + request.ActivateEnrollRequestRequestData.VehicleId + request.ActivateEnrollRequestRequestData.StartDateTime.ToFileTime().ToString());
                        data.Remark = "NPR provider service message; " + RDWres.InformationalMessage.ErrorDesc;
                        data.RemarkId = "90";
                    } else if (RDWres.PSRightCheckPSRightList != null) {
                        PSRightCheckPSRightData right = RDWres.PSRightCheckPSRightList[0];

                        //res.AuthorisationMaxAmount 
                        if (right.EndTimePSRightAdjusted.HasValue)
                            data.AuthorisationValidUntil = Denion.WebService.Functions.DateTimeToLocalTimeZone(right.EndTimePSRightAdjusted.Value);
                        else if (right.EndTimePSRight.HasValue)
                            data.AuthorisationValidUntil = Denion.WebService.Functions.DateTimeToLocalTimeZone(right.EndTimePSRight.Value);

                        data.PaymentAuthorisationId = DateTime.Now.ToFileTime().ToString() + "_" + right.PSRightId;

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

        public RevokedByThirdPartyRequestResponse RevokedByThirdParty(RevokedByThirdPartyRequestRequest request)
        {
            RevokedByThirdPartyRequestResponseData data = new RevokedByThirdPartyRequestResponseData();
            RevokedByThirdPartyRequestResponseError error = null;
            
            //data.RemarkId = "string";
            //data.Remark = "string";
            data.PaymentAuthorisationId = request.RevokedByThirdPartyRequestRequestData.PaymentAuthorisationId;

            UpdateRegistration(request.RevokedByThirdPartyRequestRequestData);
            return new RevokedByThirdPartyRequestResponse(data, error);
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
