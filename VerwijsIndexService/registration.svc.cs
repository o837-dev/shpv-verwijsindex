using Denion.WebService.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Threading;

namespace Denion.WebService.VerwijsIndex
{
    [LogBehavior]
    [ServiceBehavior(Name = "Registration", Namespace = "http://rdw.nl/rpv/1.0")]
    public class registration : Denion.WebService.VerwijsIndex.IRegistration
    {
        #region Not Implemented

        CalculatePriceResponse IRegistration.CalculatePrice(CalculatePriceRequest request)
        {
            return new CalculatePriceResponse { CalculatePriceResponseError = new CalculatePriceResponseError { ErrorCode = "140", ErrorDesc = "NotImplemented" } };
        }

        PSRightCheckResponse IRegistration.CheckPSRight(PSRightCheckRequest request)
        {
            return new PSRightCheckResponse { PSRightCheckResponseError = new PSRightCheckResponseError { ErrorCode = "140", ErrorDesc = "NotImplemented" } };
        }

        RetrieveAreaRegulationFareInfoResponse IRegistration.RetrieveAreaRegulationFareInfo(RetrieveAreaRegulationFareInfoRequest request)
        {
            return new RetrieveAreaRegulationFareInfoResponse { AreaRegulationFareInfoResponseError = new RetrieveAreaRegulationFareInfoResponseError { ErrorCode = "140", ErrorDesc = "NotImplemented" } };
        }

        RetrieveAreasByLocationResponse IRegistration.RetrieveAreasByLocation(RetrieveAreasByLocationRequest request)
        {
            return new RetrieveAreasByLocationResponse { RetrieveAreasByLocationResponseError = new RetrieveAreasByLocationResponseError { ErrorCode = "140", ErrorDesc = "NotImplemented" } };
        }

        RetrieveCheckInfoResponse IRegistration.RetrieveCheckInfo(RetrieveCheckInfoRequest request)
        {
            return new RetrieveCheckInfoResponse { CheckInfoResponseError = new RetrieveCheckInfoResponseError { ErrorCode = "140", ErrorDesc = "NotImplemented" } };
        }

        RetrieveRightInfoResponse IRegistration.RetrieveRightInfo(RetrieveRightInfoRequest request)
        {
            return new RetrieveRightInfoResponse { RightInfoResponseError = new RetrieveRightInfoResponseError { ErrorCode = "140", ErrorDesc = "NotImplemented" } };
        }

        RetrieveRightInfoForProviderResponse IRegistration.RetrieveRightInfoForProvider(RetrieveRightInfoForProviderRequest request)
        {
            return new RetrieveRightInfoForProviderResponse { RightInfoForProviderResponseError = new RetrieveRightInfoForProviderResponseError { ErrorCode = "140", ErrorDesc = "NotImplemented" } };
        }

        #endregion

        PSRightEnrollResponse IRegistration.EnrollPSRight(PSRightEnrollRequest request) {
            Timing t = new Timing("EnrollPSRight", Service.IncomingAddress(), Service.OperationContextAddress());
            PSRightEnrollResponse res = new PSRightEnrollResponse();

            Err vErr = request.IsValid();
            if (vErr != null) {
                res.PSRightEnrollResponseError = new PSRightEnrollResponseError {
                    ErrorDesc = vErr.Remark,
                    ErrorCode = vErr.RemarkId
                };
            } else {
                Worker worker = new EnrollPSRightWorker(request.PSRightEnrollRequestData);
                Thread newThread = new Thread(new ThreadStart(worker.Settle));
                newThread.Name = "EnrollPSRight";
                newThread.Start();

                if (newThread.Join(DatabaseFunctions.GetProperty("StartRequestTimeout", 2000))) {
                    res = worker.Result as PSRightEnrollResponse;
                } else {
                    worker.Abort();
                    if (worker.Result != null) {
                        res = worker.Result as PSRightEnrollResponse;
                    } else {
                        res.PSRightEnrollResponseError = new PSRightEnrollResponseError {
                            ErrorDesc = "ParkingFacility does not respond",
                            ErrorCode = "15",
                        };
                    }
                }

                if (res.PSRightEnrollResponseError == null) {
                    if (res.PSRightEnrollResponseData == null || string.IsNullOrEmpty(res.PSRightEnrollResponseData.PSRightId)) {
                        res.PSRightEnrollResponseError = new PSRightEnrollResponseError {
                            ErrorDesc = "VehicleId not found at ParkingFacility",
                            ErrorCode = "150",
                        };

                        if (worker.AuthorisationRecordId != null)
                            DatabaseFunctions.UnregisterRequest(worker.AuthorisationRecordId);
                    }
                }
                t.Finish();
            }
            return res;

        }

        PSRightRevokeResponse IRegistration.RevokePSRight(PSRightRevokeRequest request)
        {
            PSRightRevokeResponse res = new PSRightRevokeResponse();

            Timing t = new Timing("RevokePSRight", Service.IncomingAddress(), Service.OperationContextAddress());

            Err vErr = null; //request.IsValid();
            if (vErr != null)
            {
                res.PSRightRevokeResponseError = new PSRightRevokeResponseError
                {
                    ErrorDesc = vErr.Remark,
                    ErrorCode = vErr.RemarkId,
                };
            }
            else
            {
                Worker worker = new RevokePSRightWorker(request.PSRightRevokeRequestData);
                Thread newThread = new Thread(new ThreadStart(worker.Settle));
                newThread.Name = "RevokePSRight";
                newThread.Start();

                if (newThread.Join(DatabaseFunctions.GetProperty("StartRequestTimeout", 2000)))
                {
                    res = worker.Result as PSRightRevokeResponse;
                }
                else
                {
                    worker.Abort();
                    if (worker.Result != null)
                    {
                        res = worker.Result as PSRightRevokeResponse;
                    }
                    else
                    {
                        res.PSRightRevokeResponseError = new PSRightRevokeResponseError
                        {
                            ErrorDesc = "ParkingFacility does not respond",
                            ErrorCode = "15",
                        };
                    }
                }

                if (res.PSRightRevokeResponseError == null)
                {
                    /*if (res.PSRightRevokeResponseData. != null)
                    {
                        err = new PSRightRevokeResponseError();
                        err.ErrorDesc = "VehicleId not found in ParkingFaclity";
                        err.ErrorCode = "10";

                        if (worker.AuthorisationRecordId != null)
                            DatabaseFunctions.UnregisterRequest(worker.AuthorisationRecordId);
                    }*/
                }
                //}
                t.Finish();
            }

            return res;


        }

        StatusRequestResponse IRegistration.StatusRequest(StatusRequestRequest request)
        {
            StatusRequestResponseData data = new StatusRequestResponseData();
            StatusRequestResponseError error = null;

            data.StatusTime = DateTime.Now;
            data.StatusRPV = "OK";
            data.StatusReference = request.StatusRequestRequestData.StatusReference;

            return new StatusRequestResponse(data, error);
        }
    }

    class EnrollPSRightWorker : Worker
    {
        /// <summary>
        /// Verzoek bericht
        /// </summary>
        private PSRightEnrollRequestData _request;

        /// <summary>
        /// Antwoord bericht
        /// </summary>
        private PSRightEnrollResponse _response;

        public EnrollPSRightWorker(PSRightEnrollRequestData request)
        {
            _request = request;
            _response = new PSRightEnrollResponse();
        }

        public override object Request
        {
            get
            {
                return _request;
            }

            set
            {
                _request = value as PSRightEnrollRequestData;
            }
        }

        public override object Result
        {
            get
            {
                return _response;
            }
        }

        public override void Settle() {
            //translate location information to AreaManagerId/AreaId
            GEOinfo gi = null;
            if (!string.IsNullOrEmpty(_request.AreaManagerId) && !string.IsNullOrEmpty(_request.AreaId)) {
                //TODO do we need additional GEO info??!
                gi = new GEOinfo {
                    AreaId = _request.AreaId,
                    AreaManagerId = _request.AreaManagerId
                };
            } else if (_request.LocationPSRight != null) {
                //translate lat/lon to AreaManagerId/AreaId
                gi = GEO.FromLatLon(_request.LocationPSRight.Latitude, _request.LocationPSRight.Longitude);
            }
            else if (!string.IsNullOrEmpty(_request.SellingPointId)) {
                //translate SellingPointId to AreaManagerId/AreaId
                gi = GEO.FromSellingPoint(_request.SellingPointId);
            } else {
                //Database.Database.Log("GEOInfo, nothing to translate..");
            }
            
            if (gi == null || gi.AreaManagerId == null || gi.AreaId == null) {
                _response.PSRightEnrollResponseError = new PSRightEnrollResponseError() {
                    ErrorCode = "145",
                    ErrorDesc = "Location unkown"
                };
                return;
            }
            _requestid = DatabaseFunctions.RegisterRequest(null, _request.VehicleId, _request.CountryCodeVehicle.ToString(), gi.AreaManagerId, _request.StartTimePSright, gi.AreaId, null);

            ActivateAuthorisationRequest req = new ActivateAuthorisationRequest();
            ActivateAuthorisationResponse res = null;

            req.AreaId = gi.AreaId;
            req.AreaManagerId = gi.AreaManagerId;
            if (_request.CountryCodeVehicle.HasValue)
                req.CountryCode = _request.CountryCodeVehicle.Value.ToString();
            if (_request.EndTimePSright.HasValue)
                req.EndDateTime = _request.EndTimePSright.Value;
            //req.PaymentAuthorisationId = _request.
            req.ProviderId = _request.ProviderId;
            req.VehicleId = _request.VehicleId;
            req.VehicleIdType = _request.VehicleIdType;

            // select parkingfacility from DB
            Providers parkingFacility = DatabaseFunctions.ListOfParkingFacilities(gi.AreaManagerId, gi.AreaId, _request.StartTimePSright);
            if (parkingFacility.Count > 0) {
                foreach (Provider p in parkingFacility) {
                    ConsumerClient clnt = null;
                    try {
                        Timing t = new Timing("RegistrationService", "ActivateAuthorisation", p.url);
                        clnt = Service.Consumer(p.url);

                        ActivateAuthorisationResponse relayRes = clnt.ActivateAuthorisation(req);
                        t.Finish();

                        if (relayRes != null) {
                            res = relayRes;
                            if (!string.IsNullOrEmpty(relayRes.PaymentAuthorisationId)) {
                                Link link = DatabaseFunctions.CreateLink(req.VehicleId, req.CountryCode, req.ProviderId, null, _request.StartTimePSright, req.EndDateTime, null, req.AreaId, req.VehicleIdType, null);

                                DatabaseFunctions.UpdateAuthorisation(req.ProviderId, relayRes.PaymentAuthorisationId, null, _requestid, link);

                                clnt.Close();
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Database.Database.Log(string.Format("Exception on ActivateAuthorisation from ({2}); {0}; {1}", ex.Message, ex.StackTrace, p.url));
                    }
                    finally
                    {
                        if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                            clnt.Close();
                    }
                }
            }
            else
            {
                //_responsebase._responsebase.Log(string.Format("No contract found; area: {0}; startdate: {1}", gi.AreaManagerId, _request.StartDateTime));
                //res.RemarkId = "115";
                //_response.Remark = "No available contract";
            }
            
            // translate answer back
            if (res != null)
            {
                if (res.Granted.HasValue)
                {
                    _response.PSRightEnrollResponseData = new PSRightEnrollResponseData
                    {
                        AmountPSright = _request.AmountPSright,
                        AmountPSrightSpecified = _request.AmountPSrightSpecified,

                        AmountPSRightCalculated = Convert.ToDecimal(res.Amount),
                        AmountPSRightCalculatedSpecified = res.Amount.HasValue,

                        AreaId = req.AreaId,

                        AreaManagerId = req.AreaManagerId,

                        EndTimePSright = _request.EndTimePSright,
                        EndTimePSrightSpecified = _request.EndTimePSrightSpecified,

                        EndTimePSRightAdjusted = res.EndDateTime,
                        EndTimePSRightAdjustedSpecified = res.EndDateTime.HasValue,

                        PSRightId = res.PaymentAuthorisationId,

                        //PSRightRemarkList = new PSRightRemark_response[] { new PSRightRemark_response() { PSRightRemarkType = KindOfRemarksType.Item1 } };

                        //SellingPointId = ;

                        //SpecifCalcAmountList = new SpecifCalcAmount_response[] { new SpecifCalcAmount_response() { RegulationId = "string" } };

                        StartTimeAdjusted = res.StartDateTimeAdjusted,
                        StartTimeAdjustedSpecified = res.StartDateTimeAdjusted.HasValue,
                        
                        VATPSright = Convert.ToDecimal(_request.VATPSright),
                        VATPSrightSpecified = _request.VATPSright.HasValue,

                        VATPSRightCalculated = Convert.ToDecimal(res.VAT),
                        VATPSRightCalculatedSpecified = res.VAT.HasValue,
                    };
                }
                if (!string.IsNullOrEmpty(res.Remark))
                {
                    _response.PSRightEnrollResponseError = new PSRightEnrollResponseError
                    {
                        //AreaManagerId = "string",
                        //AreaTable = new Area_response[] { new Area_response() { UsageDesc = "string" } },
                        //CountryCodeVehicle = null,
                        ErrorCode = res.RemarkId,
                        ErrorDesc = res.Remark,
                        //ErrorVariable = "string",
                        //LocationPSRight = new PSRightEnrollResponseErrorLocationPSRight() { Latitude = "string", Longitude = "string" },
                        //SellingPointId = "string",
                        //UsageId = "string",
                        //VehicleId = "string",
                    };
                }
            }
        }

        public override void UnSettle()
        {
            throw new NotImplementedException();
        }
    }

    class RevokePSRightWorker : Worker
    {
        /// <summary>
        /// Verzoek bericht
        /// </summary>
        private PSRightRevokeRequestData _request;

        public override object Request
        {
            get
            {
                return _request;
            }

            set
            {
                _request = value as PSRightRevokeRequestData;
            }
        }

        /// <summary>
        /// Antwoord bericht
        /// </summary>
        private PSRightRevokeResponse _response;

        public RevokePSRightWorker(PSRightRevokeRequestData pSRightRevokeRequestData)
        {
            _request = pSRightRevokeRequestData;
            _response = new PSRightRevokeResponse();
        }

        public override object Result
        {
            get
            {
                return _response;
            }
        }

        public override void Settle()
        {
            try
            {
                CancelAuthorisationRequest req = new CancelAuthorisationRequest();
                CancelAuthorisationResponse res = null;

                SqlCommand com = new SqlCommand();
                com.CommandText = @"Select c.id, a.ProviderId, c.DESCRIPTION, c.URL, a.STARTDATE, a.AREAID, a.AREAMANAGERID, a.VehicleId, a.CountryCode, a.VehicleIdType
                    from Authorisation a 
                    join ConsumerContract cc on a.AREAMANAGERID= cc.AREAMANAGERID and a.AreaId = cc.AreaId and a.STARTDATE between cc.STARTDATE and cc.ENDDATE
                    join Consumer c on cc.CONSUMERID = c.CID 
                     where a.AUTHORISATIONID=@AUTHORISATIONID";

                com.Parameters.Add("@AUTHORISATIONID", System.Data.SqlDbType.NVarChar, 50).Value = _request.PSRightId;
                DataTable dt = Database.Database.ExecuteQuery(com);
                if (dt != null && dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];

                    req.AreaId = dr["AreaId"] as string;
                    req.AreaManagerId = dr["AreaManagerId"] as string;
                    req.CancelDateTime = _request.EndTimePSRight;
                    req.CountryCode = dr["CountryCode"] as string;
                    req.PaymentAuthorisationId = _request.PSRightId;
                    req.ProviderId = dr["ProviderId"] as string;
                    req.VehicleId = Cryptography.Rijndael.Decrypt(dr["VehicleId"] as string);
                    req.VehicleIdType = dr["VehicleIdType"] as string;

                    // select parkingfacility from DB
                    Providers providers = DatabaseFunctions.ListOfParkingFacilities(req.AreaManagerId, req.AreaId, _request.EndTimePSRight);
                    if (providers.Count > 0)
                    {
                        foreach (Provider p in providers)
                        {
                            ConsumerClient clnt = null;
                            try
                            {
                                Timing t = new Timing("RegistrationService", "CancelAuthorisation", p.url);
                                clnt = Service.Consumer(p.url);

                                CancelAuthorisationResponse relayRes = clnt.CancelAuthorisation(req);
                                t.Finish();

                                if (relayRes != null)
                                {
                                    res = relayRes;
                                    if (!string.IsNullOrEmpty(relayRes.PaymentAuthorisationId))
                                    {
                                        bool nprRegistration = getNprRegistration(req.ProviderId, req.AreaManagerId);
                                        Database.Database.Log("providerId:" + req.ProviderId + ", AreaManagerId " + req.AreaManagerId);

                                        object PSRightID = DBNull.Value;
                                        Database.Database.Log("NPR Registration? " + nprRegistration);
                                        if (nprRegistration) {
                                            DateTime endTime = res.EndTimeAdjusted != null? res.EndTimeAdjusted.Value : req.CancelDateTime.Value;

                                            res.Amount = res.Amount == null ? 0 : res.Amount;
                                            RDWRight r = WebService.Functions.RDWEnrollRight((string)dr["PROVIDERID"], (string)dr["AreaManagerId"], (string)dr["AreaId"], "BETAALDP", req.VehicleId, (DateTime)dr["STARTDATE"], res.EndTimeAdjusted , req.CountryCode, Convert.ToDecimal(res.Amount), Convert.ToDecimal(res.VAT), res.PaymentAuthorisationId);
                                            if (r.PSRightId != null)
                                                PSRightID = r.PSRightId;
                                            if (!string.IsNullOrEmpty(r.Remark)) {
                                                res.RemarkId = "120";
                                                res.Remark = "Problem with NPR registration; " + r.Remark;
                                            }
                                        }
                                        AuthorisationSettled(res.PaymentAuthorisationId, PSRightID);

                                        clnt.Close();
                                        break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Database.Database.Log(string.Format("Exception on CancelAuthorisation from ({2}); {0}; {1}", ex.Message, ex.StackTrace, p.url));
                            }
                            finally
                            {
                                if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                                    clnt.Close();
                            }
                        }
                    }
                    else
                    {
                        //_responsebase._responsebase.Log(string.Format("No contract found; area: {0}; startdate: {1}", _request.AreaManagerId, _request.StartDateTime));
                        //res.RemarkId = "115";
                        //_response.Remark = "No available contract";
                    }

                    // translate answer back
                    if (res != null)
                    {
                        //res.CanceledDateTime
                        //res.Granted
                        //res.PaymentAuthorisationId
                        //res.ProviderId
                        if (res.Granted.HasValue)
                        {
                            _response.PSRightRevokeResponseData = new PSRightRevokeResponseData
                            {
                                EndTimePSRightAdjusted = res.EndTimeAdjusted,
                                EndTimePSRightAdjustedSpecified = res.EndTimeAdjusted.HasValue,
                                StartTimePSRightAdjusted = res.StartTimeAdjusted,
                                StartTimePSRightAdjustedSpecified = res.StartTimeAdjusted.HasValue,
                                //PSRightRemarkList = new PSRightRemarkData[] { new PSRightRemarkData { PSRightRemarkType = KindOfRemarksType.Item2 } },
                                //SpecifCalcAmountList = new SpecifCalcAmountData[] { new SpecifCalcAmountData { RegulationId = "string" } },
                            };
                            if (res.Amount.HasValue)
                            {
                                _response.PSRightRevokeResponseData.AmountPSRightCalculated = new decimal(res.Amount.Value);
                                _response.PSRightRevokeResponseData.AmountPSRightCalculatedSpecified = res.Amount.HasValue;
                            }
                            if (res.VAT.HasValue)
                            {
                                _response.PSRightRevokeResponseData.VATPSRightCalculated = new decimal(res.VAT.Value);
                                _response.PSRightRevokeResponseData.VATPSRightCalculatedSpecified = res.VAT.HasValue;
                            }
                        }
                        //res.Remark
                        //res.RemarkId
                        if (!string.IsNullOrEmpty(res.Remark))
                        {
                            _response.PSRightRevokeResponseError = new PSRightRevokeResponseError
                            {
                                ErrorCode = res.RemarkId,
                                ErrorDesc = res.Remark,
                            };
                        }
                    }
                }
                else
                {
                    _response.PSRightRevokeResponseError = new PSRightRevokeResponseError
                    {
                        ErrorCode = "155",
                        ErrorDesc = "Authorisation was not found in the system"
                    };
                }
            }
            catch (Exception ex)
            {
                Database.Database.Log("RevokePSRightWorker error; " + ex.Message + "; " + ex.StackTrace);

                _response.PSRightRevokeResponseError = new PSRightRevokeResponseError
                {
                    ErrorCode = "100",
                    ErrorDesc = "Internal error"
                };
            }
        }

        private bool getNprRegistration(object providerId, object areaManagerId) {
            SqlCommand com = new SqlCommand();
            com.CommandText = @"Select c.NPRREGISTRATION
                    from [Provider] as p 
                    join [Contract] as c on c.PROVIDERID2 = p.PID 
                     where p.ID = @PROVIDERID and c.AREAMANAGERID = @AREAMANAGERID";

            com.Parameters.Add("@PROVIDERID", System.Data.SqlDbType.NVarChar, 50).Value = providerId;
            com.Parameters.Add("@AREAMANAGERID", System.Data.SqlDbType.NVarChar, 50).Value = areaManagerId;
            DataTable dt = Database.Database.ExecuteQuery(com);
            if (dt != null && dt.Rows.Count == 1) {
                DataRow dr = dt.Rows[0];
              
                return (bool)dr["NPRREGISTRATION"];
            }

            return false;
        }

        private static void AuthorisationSettled(string PaymentAuthorisationId, object PSRightId)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "Update Authorisation set SETTLED=@SETTLED, PSRIGHTID=@PSRIGHTID where AUTHORISATIONID=@AUTHORISATIONID";
            com.Parameters.Add("@SETTLED", SqlDbType.Bit).Value = true;
            com.Parameters.Add("@AUTHORISATIONID", SqlDbType.VarChar, 50).Value = PaymentAuthorisationId;
            com.Parameters.Add("@PSRIGHTID", SqlDbType.NVarChar, 50).Value = PSRightId;

            Database.Database.ExecuteQuery(com);
        }

        public override void UnSettle()
        {
            throw new NotImplementedException();
        }
    }
}
